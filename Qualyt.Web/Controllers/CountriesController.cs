using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using Qualyt.Services.Services;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class CountriesController : CrudController<Country>
    {
        private ICountriesService _service;
        public CountriesController(ICountriesService service):base(service.Query(),service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IEnumerable<Country> GetAllByUser()
        {
            return _service.GetAllByUser();
        }

        public override Expression<Func<Country, bool>> Filter(string filterValue)
        {
            return (x) => 
                x.Name.Contains(filterValue)
                || x.Id.ToString().Contains(filterValue)
                //|| (x.Active && ("Activa").Contains(filterValue))
                //|| (!x.Active && ("Inactiva").Contains(filterValue))
                ;
        }

        public override Expression<Func<Country, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "name": return (x) => x.Name;
                //case "active": return (x) => x.Active;
                case "id": return (x) => x.Id;
                default: return (x) => x.Name;
            }
        }
    }
}
