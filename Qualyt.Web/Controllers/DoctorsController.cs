using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Validation;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Stats;
using Qualyt.Domain.Models.Users;
using Qualyt.Services.Services;
using Qualyt.Web.ViewModels;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class DoctorsController : DatatableController<Doctor>
    {
        private IDoctorsService _service;
        private IDoctorSpecialtiesService _specialtiesService;
        public DoctorsController(IDoctorsService service, IDoctorSpecialtiesService specialtiesService)
            :base(
                 service.Query()
                 .Include(x=>x.AttentionPlace)
                 .Include(x=>x.SalesContact)
                 .Include(x=>x.Specialty)
                 .Include(x=>x.Country))
        {
            _service = service;
            _specialtiesService = specialtiesService;
        }



        [HttpGet("[action]")]
        public virtual IEnumerable<Doctor> Get()
        {
            return _service.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public Doctor Get(long id)
        {
            var objeto = _service.GetById(id);
            return objeto;
        }

        [HttpPost("[action]")]
        public virtual Doctor Post([FromBody] Doctor value)
        {
            value.AttentionPlace = null;
            _service.Add(value);
            value.Specialty = _specialtiesService.GetById(value.SpecialtyId);
            return value;
        }

        [HttpPut("[action]")]
        public virtual void Put([FromBody] Doctor value)
        {
            _service.Update(value);
        }

        [HttpDelete("[action]/{id}")]
        public void Delete(string id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("CONSTRAINT"))
                    ModelState.AddModelError("", "No se puede borrar porque existen entidades relacionadas con esta.");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado.");
            }
        }

        [HttpGet("[action]/{id}")]
        public Doctor GetOneById(string id)
        {
            return _service.GetOneById(id);
        }
        [HttpPost("[action]")]
        public long GetDoctorsCount([FromBody] DashboardFilter filter)
        { return _service.GetDoctorsCount(filter); }
        [HttpPost("[action]")]
        public long GetDoctorsCountLastMonth([FromBody] DashboardFilter filter)
        { return _service.GetDoctorsCountLastMonth(filter); }
        public override Expression<Func<Doctor, bool>> Filter(string filterValue)
        {
            return (x) =>
                RemoveDiacritics(x.FullName.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.SalesContact.FullName.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Specialty.Name.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.AttentionPlace.Name.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Country.Name.ToLower()).Contains(filterValue)
            ;
        }

        public override Expression<Func<Doctor, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "fullName": return (x) => x.FullName;
                case "salesContact.fullName": return (x) => x.SalesContact.FullName;
                case "specialty.name": return (x) => x.Specialty.Name;
                case "attentionPlace.name": return (x) => x.AttentionPlace.Name;
                case "country.name": return (x) => x.Country.Name;
                default: return (x) => x.Name;
            }
        }
    }
}
