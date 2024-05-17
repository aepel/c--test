using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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
    public class PatientsTermsAcceptanceController : Controller
    {
        private IPatientsService _service;
        private ITermsAndConditionsService _serviceTermsAndConditions;
        private IEmailSender emailSender;

        public PatientsTermsAcceptanceController(IPatientsService service, IEmailSender sender, ITermsAndConditionsService terms)
        {
            _service = service;
            emailSender = sender;
            _serviceTermsAndConditions = terms;
        }

        [HttpPost("acceptTerms")]
        public void AcceptTerms([FromBody] long Id)
        {
            _service.AcceptTerms(Id);
        }

        [HttpGet("getHashed")]
        public Patient GetHashed(string hash, string number)
        {
            return _service.GetHashed(hash, number);
        }
    }
}
