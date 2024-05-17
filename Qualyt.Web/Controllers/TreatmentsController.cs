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
using Qualyt.Domain.Models.Stats;
using Qualyt.Services.Services;
using Qualyt.Web.Helpers;
using Qualyt.Web.ViewModels;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class TreatmentsController : DatatableController<Treatment>
    {
        private ITreatmentsService _service;
        public TreatmentsController(ITreatmentsService service):base(service.Query()
            .Include(x=>x.Doctor)
            .Include(x=>x.Patient).Include(x=>x.Pathology))
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public Treatment Post([FromBody] TreatmentViewModel value)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            var treatment = mapper.Map<Treatment>(value);
            _service.Add(treatment);
            return treatment;
        }

        [HttpGet("[action]")]
        public IEnumerable<Treatment> Get()
        {
            return _service.GetAll();
        }

        [HttpPost("[action]")]
        public long GetTreatmentsCount([FromBody] DashboardFilter filter)
        {
            return _service.GetTreatmentsCount(filter);
        }

        [HttpPost("[action]")]
        public long GetTreatmentsCountLastMonth([FromBody] DashboardFilter filter)
        { return _service.GetTreatmentsCountLastMonth(filter); }

        [HttpGet("[action]/{id}")]
        public Treatment Get(long id)
        {
            return _service.GetById(id);
        }

        [HttpPut("[action]")]
        public void Put([FromBody] TreatmentViewModel value)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            var treatment = mapper.Map<Treatment>(value);
            _service.Update(treatment);
        }

        [HttpDelete("[action]/{id}")]
        public void Delete(long id)
        {
            _service.Remove(id);
        }

        public override Expression<Func<Treatment, bool>> Filter(string filterValue)
        {
            return (x) => 
                RemoveDiacritics(x.Patient.FullName.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Doctor.FullName.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Pathology.Name.ToLower()).Contains(filterValue)
                || x.CreatedDate.ToString("d/M/yy, h:mm a").ToLower().Contains(filterValue)
                ;
        }

        public override Expression<Func<Treatment, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                //case "active": return (x) => x.Active;
                case "patient.fullName": return (x) => x.Patient.FullName;
                case "doctor.fullName": return (x) => x.Doctor.FullName;
                case "pathology.name": return (x) => x.Pathology.Name;
                case "createdDate": return (x) => x.CreatedDate;
                default: return (x) => x.CreatedDate;
            }
        }
    }
}
