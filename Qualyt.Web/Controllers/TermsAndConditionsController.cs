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
using Qualyt.Services.Services;
using Qualyt.Web.Helpers;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class TermsAndConditionsController : CrudController<TermsAndConditions>
    {
        private ITermsAndConditionsService _service;
        private IEmailSender _emailSender;
        public TermsAndConditionsController(ITermsAndConditionsService service, IEmailSender emailSender) :base(service.Query(), service)
        {
            _service = service;
            _emailSender = emailSender;
        }


        [HttpGet("getText")]
        [AllowAnonymous]
        public string GetText()
        {
            return _service.GetLastPublished() != null ? _service.GetLastPublished().Text : "";
        }

        [HttpGet("getEmailToReceive")]
        [AllowAnonymous]
        public string GetEmailToReceive()
        {
            return _emailSender.GetEmailToReceive();
        }

        [HttpPost("publish")]
        public bool Publish([FromBody]int id)
        {
            _service.Publish(id, this.GetUserId());
            return true;
        }

        public override Expression<Func<TermsAndConditions, bool>> Filter(string filterValue)
        {
            return (x) => 
                (x.PublishedDate.HasValue?x.PublishedDate.Value.ToString("d/M/yy, h:mm a").ToLower().Contains(filterValue):"no aplica".Contains(filterValue))
                || (x.Version.HasValue ? x.Version.ToString().ToLower().Contains(filterValue) : "no aplica".Contains(filterValue))
                || (x.Published?"si".Contains(filterValue):"no".Contains(filterValue))
                || (x.Active?"si".Contains(filterValue):"no".Contains(filterValue))
                ;
        }

        public override Expression<Func<TermsAndConditions, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "publishedDate": return (x) => x.PublishedDate;
                case "vesion": return (x) => x.Version;
                case "published": return (x) => x.Published;
                case "active": return (x) => x.Active;
                default: return (x) => x.Id;
            }
        }
    }
}
