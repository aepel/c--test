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

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleService _service;
        private IEmailSender _sender;
        private DatosTagSettings _settings;
        public ScheduleController(IScheduleService service, IOptions<DatosTagSettings> settings, IEmailSender sender)
        {
            _service = service;
            _settings = settings.Value;
            _sender = sender;
        }

        [HttpGet("[action]/{token}")]
        public virtual void NotifyTomorrowControls(string token)
        {
            if (token == _settings.ScheduleToken)
            {
                var treatments=_service.GetEmailsToNotifyTomorrowControls();
                _sender.SendNotifyTomorrowControlsMailAsync(treatments);
            }
        }
    }
}
