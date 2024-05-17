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
using Qualyt.Domain.Models.Users;
using Qualyt.Services.Services;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class NursesController : CrudController<Nurse>
    {
        private INursesService _service;
        public NursesController(INursesService service):base(service.Query().Include(x=>x.Country),service)
        {
            _service = service;
        }
        
        public override Expression<Func<Nurse, bool>> Filter(string filterValue)
        {
            return (x) => 
                RemoveDiacritics(x.FullName.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Country.Name.ToLower()).Contains(filterValue)
                ;
        }

        public override Expression<Func<Nurse, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "fullName": return (x) => x.FullName;
                case "country.name": return (x) => x.Country.Name;
                default: return (x) => x.Name;
            }
        }
    }
}
