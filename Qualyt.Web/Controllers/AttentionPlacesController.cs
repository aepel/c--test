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
    public class AttentionPlacesController : CrudController<AttentionPlace>
    {
        private IAttentionPlacesService _service;
        public AttentionPlacesController(IAttentionPlacesService service):base(service.Query(),service)
        {
            _service = service;
        }
        
        public override Expression<Func<AttentionPlace, bool>> Filter(string filterValue)
        {
            return (x) => 
                x.Name.ToLower().Contains(filterValue)
                ;
        }

        public override Expression<Func<AttentionPlace, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "name": return (x) => x.Name;
                default: return (x) => x.Name;
            }
        }
    }
}
