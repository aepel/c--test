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
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
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
    public class HealthInsurancesController : DatatableController<HealthInsurance>
    {
        private IHealthInsurancesService _service;
        public HealthInsurancesController(IHealthInsurancesService service):base(service.Query().Include(x=>x.Country))
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public virtual IEnumerable<HealthInsurance> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("[action]/{id}")]
        public HealthInsurance Get(long id)
        {
            var objeto = _service.GetById(id);
            return objeto;
        }


        [HttpDelete("[action]/{id}")]
        public void Delete(long id)
        {
            _service.Remove(id);
        }

        [HttpPost("[action]")]
        public void Post([FromBody] HealthInsuranceViewModel value)
        {
            try
            {
                var mapper = AutoMapperConfiguration.GetMapper();
                var baseValue = mapper.Map<HealthInsurance>(value);
                _service.Add(baseValue);
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if(e.Message.Contains("Duplicate") && e.Message.Contains("Name"))
                    ModelState.AddModelError("", "El nombre proporcionado es igual a uno existente");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado");
            }
        }

        [HttpPut("[action]")]
        public void Put([FromBody] HealthInsuranceViewModel value)
        {
            try
            {
                var mapper = AutoMapperConfiguration.GetMapper();
                var baseValue = mapper.Map<HealthInsurance>(value);
                _service.Update(baseValue);
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("Duplicate") && e.Message.Contains("Name"))
                    ModelState.AddModelError("", "El nombre proporcionado es igual a uno existente");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado");
            }
        }

        public override Expression<Func<HealthInsurance, bool>> Filter(string filterValue)
        {
            return (x) => 
                RemoveDiacritics(x.Name.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Country.Name.ToLower()).ToString().Contains(filterValue)
                ;
        }

        public override Expression<Func<HealthInsurance, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "name": return (x) => x.Name;
                case "country.name": return (x) => x.Country.Name;
                default: return (x) => x.Name;
            }
        }
    }
}
