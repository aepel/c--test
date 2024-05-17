using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Validation;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Stats;
using Qualyt.Services.Services;
using Qualyt.Web.Helpers;
using Qualyt.Web.Validators;
using Qualyt.Web.ViewModels;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class PatientsController : DatatableController<Patient>
    {
        private IPatientsService _service;
        private ITermsAndConditionsService _serviceTermsAndConditions;
        private IEmailSender emailSender;

        public PatientsController(IPatientsService service, IEmailSender sender, ITermsAndConditionsService terms) : base(
            service.GetPatients()
            )
        {
            _service = service;
            emailSender = sender;
            _serviceTermsAndConditions = terms;
        }

        [HttpGet("[action]")]
        public virtual IEnumerable<Patient> Get()
        {
            return _service.GetAll();
        }
        [HttpPost("[action]")]
        public long GetPatientsCount([FromBody] DashboardFilter filter)
        {
            return _service.GetPatientsCount(filter);
        }
        [HttpPost("[action]")]
        public long GetPatientsCountLastMonth([FromBody] DashboardFilter filter)
        {
            return _service.GetPatientsCountLastMonth(filter);
        }
        [HttpGet("[action]/{id}")]
        public Patient Get(long id)
        {
            var objeto = _service.GetById(id);
            return objeto;
        }
        [HttpGet("[action]/{id}")]
        public Patient GetWithoutFiles(long id)
        {
            var objeto = _service.GetWithoutFiles(id);
            return objeto;
        }


        [HttpDelete("[action]/{id}")]
        public void Delete(long id)
        {
            try
            {
                _service.Remove(id);
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("CONSTRAINT"))
                    ModelState.AddModelError("", "No se puede eliminar");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado");
            }
        }

        [HttpGet("[action]/{id}")]
        public List<Patient> GetByDoctor(string id)
        {
            return _service.GetByDoctor(id);
        }

        [HttpPost("[action]")]
        public Patient Post([FromBody] PatientViewModel patient)
        {
            try
            {
                var mapper = AutoMapperConfiguration.GetMapper();
                var value = mapper.Map<Patient>(patient);
                _service.Add(value);
             /*   if (_service.TermsAcceptmentIsRequired(value))
                {
                    emailSender.SendTermsAndConditionsMailAsync(value, Url);
                    _service.TermsSended(value.Id);
                }*/
                return value;
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("Duplicate") && e.Message.Contains("PlanId") && e.Message.Contains("IdNumber"))
                    ModelState.AddModelError("", "Ya existe un paciente cargado con este número de identificación (RUT, DNI) asignado al plan seleccionado");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado");
                return null;
            }
        }

        [HttpPut("[action]")]
        public void Put([FromBody] PatientViewModel patient)
        {
            try
            {
                var mapper = AutoMapperConfiguration.GetMapper();
                var value = mapper.Map<Patient>(patient);
                _service.Update(value);
                if(_service.TermsAcceptmentIsRequired(value))
                {
                    emailSender.SendTermsAndConditionsMailAsync(value, Url);
                    _service.TermsSended(value.Id);
                }
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("Duplicate") && e.Message.Contains("PlanId") && e.Message.Contains("IdNumber"))
                    ModelState.AddModelError("", "Ya existe un paciente cargado con este número de identificación (RUT, DNI) asignado al plan seleccionado");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado");
            }
        }

        [HttpPost("acceptTerms")]
        public void AcceptTerms([FromBody] long Id)
        {
            _service.AcceptTerms(Id);
        }

        [HttpPost("[action]")]
        public void ToggleActive([FromBody] long Id)
        {
            _service.ToggleActive(Id);
        }

        [HttpPost("uploadFile"),DisableRequestSizeLimit]
        public void UploadFile(IFormFile file, long id)
        {
            _service.AcceptTerms(file,id);
        }

        [HttpGet("downloadFiles"), DisableRequestSizeLimit]
        public List<AttachedFile> DownloadFiles(long id)
        {
            var list= _service.GetAcceptedTerms(id);
            return list;
        }

        [HttpGet("downloadFile"), DisableRequestSizeLimit]
        public Byte[] DownloadFile(long id)
        {
            return _service.GetFile(id);
        }

        [HttpPost("removeFile"), DisableRequestSizeLimit]
        public void Remove([FromBody]long fileId)
        {
            _service.RemoveFile(fileId);
        }

        public override Expression<Func<Patient, bool>> Filter(string filterValue)
        {
            return (x) => 
                RemoveDiacritics(x.Code.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.FullName.ToLower()).ToString().Contains(filterValue)
                || RemoveDiacritics(x.Doctor.FullName.ToLower()).ToString().Contains(filterValue)
                || RemoveDiacritics(x.Country.Name.ToLower()).ToString().Contains(filterValue)
                || RemoveDiacritics(x.Plan.Name.ToLower()).ToString().Contains(filterValue)
                || RemoveDiacritics(x.HealthInsurance.Name.ToLower()).ToString().Contains(filterValue)
                || x.BirthDate.ToString("d/M/yy, h:mm a").ToLower().Contains(filterValue)
                || x.StateName.ToLower().ToString().Contains(filterValue)
                || (x.Active?"si".Contains(filterValue):"no".Contains(filterValue))
                ;
        }

        public override Expression<Func<Patient, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "code": return (x) => x.Code;
                case "fullName": return (x) => x.FullName;
                case "doctor.fullName": return (x) => x.Doctor.FullName;
                case "country.name": return (x) => x.Country.Name;
                case "healthInsurance.name": return (x) => x.HealthInsurance.Name;
                case "plan.name": return (x) => x.Plan.Name;
                case "birthDate": return (x) => x.BirthDate;
                case "stateName": return (x) => x.StateName;
                case "active": return (x) => x.Active;
                default: return (x) => x.FullName;
            }
        }
    }
}
