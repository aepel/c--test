using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenIddict.Validation;
using Qualyt.Domain.Models.Mails.Config;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using Qualyt.Services.Services;
using Qualyt.Web.Helpers;
using Qualyt.Web.ViewModels;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class AlertsController : ControllerBase
    {
        private IAlertsService _service;

        public AlertsController(IAlertsService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public virtual List<Alert> GetAlerts()
        {
            var alerts = new List<Alert>();
            alerts.AddRange(
                _service.PatientsWithoutConsent().Select(x=>
                    new PatientWithoutConsentAlert()
                    {
                        PatientId=x.Id,
                        PatientName=x.FullName
                    }
                )
            );
            alerts.AddRange(
                _service.TodayControls().Select(x =>
                    new TodayControlAlert()
                    {
                        PatientName=x.Patient.FullName,
                        TreatmentId=x.Id
                    }
                )
            );
            return alerts;
        }
    }
}
