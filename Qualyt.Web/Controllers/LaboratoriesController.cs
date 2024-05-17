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
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Services.Services;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class LaboratoriesController : CrudController<Laboratory>
    {
        private ILaboratoriesService _service;
        public LaboratoriesController(ILaboratoriesService service):base(service.GetLaboratoriesWithoutIcon(),service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public override IEnumerable<Laboratory> Get()
        {
            return _service.GetLaboratoriesWithoutIcon().ToList();
        }

        [HttpGet("[action]")]
        public IEnumerable<Laboratory> GetWithIcon()
        {
            return _service.GetAll();
        }

        [HttpPost("uploadIcon"), DisableRequestSizeLimit]
        public void UploadIcon(long id)
        {
            var icon=HttpContext.Request.Form.Files.FirstOrDefault();
            _service.SaveIcon(icon, id);
        }

        [HttpGet("downloadIcon"), DisableRequestSizeLimit]
        public byte[] DownloadIcon(long id)
        {
            return _service.DownloadIcon(id);
        }

        public override Expression<Func<Laboratory, bool>> Filter(string filterValue)
        {
            return (x) => 
                RemoveDiacritics(x.Name.ToLower()).Contains(filterValue)
                //|| (x.Active && ("Activa").Contains(filterValue))
                //|| (!x.Active && ("Inactiva").Contains(filterValue))
                ;
        }

        public override Expression<Func<Laboratory, object>> OrderCondition(string propertyName)
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
