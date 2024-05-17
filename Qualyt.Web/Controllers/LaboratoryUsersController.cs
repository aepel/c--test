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
    public class LaboratoryUsersController : CrudController<LaboratoryUser>
    {
        private ILaboratoryUsersService _service;
        public LaboratoryUsersController(ILaboratoryUsersService service):base(service.Query(),service)
        {
            _service = service;
        }

        [HttpGet("[action]/{id}")]
        public LaboratoryUser GetOneById(string id)
        {
            var objeto = _service.GetOneById(id);
            return objeto;
        }

        public override Expression<Func<LaboratoryUser, bool>> Filter(string filterValue)
        {
            return (x) => 
                x.UserName.ToLower().Contains(filterValue)
                ;
        }

        public override Expression<Func<LaboratoryUser, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                default: return (x) => x.UserName;
            }
        }
    }
}
