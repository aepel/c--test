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
using Qualyt.Domain.Models.Stats;
using Qualyt.Domain.Models.Users;
using Qualyt.Services.Services;
using Qualyt.Web.Validators;
using Qualyt.Web.ViewModels;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class PlansController : CrudController<Plan>
    {
        private IPlansService _service;
        public PlansController(IPlansService service):base
            (service.Query()
            .Include(x=>x.PlanProducts)
            .Include(x=>x.PlanPathologies)
            .Include(x=>x.Laboratory)
            .Include(x=>x.Country)
            ,service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public override Plan Post([FromBody] Plan value)
        {
            try
            {
                return base.Post(value);
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("IX_plans_Name"))
                    ModelState.AddModelError("", "Ya existe un programa con este nombre");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado.");
                return null;
            }
        }

        [HttpPut("[action]")]
        public override void Put([FromBody] Plan value)
        {
            try
            {
                base.Put(value);
            }
            catch (Exception e)
            {
                while (e.InnerException != null) { e = e.InnerException; }
                if (e.Message.Contains("IX_plans_Name"))
                    ModelState.AddModelError("", "Ya existe un programa con este nombre");
                else
                    ModelState.AddModelError("", "Ha ocurrido un error inesperado.");
            }
        }

        [HttpPost("[action]")]
        public List<PivotTableData> GetPivotTableData([FromBody] DashboardFilter filter)
        {
            return _service.GetPivotTableData(filter);
        }

        [HttpGet("[action]")]
        public virtual IEnumerable<Plan> GetAllByUser()
        {
            return _service.GetAllByUser();
        }

        [HttpGet("[action]")]
        public virtual IEnumerable<Plan> GetActivesByUser()
        {
            return _service.GetActivesByUser();
        }

        public override Expression<Func<Plan, bool>> Filter(string filterValue)
        {
            return (x) => 
                RemoveDiacritics(x.Name.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Laboratory.Name.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Country.Name.ToLower()).Contains(filterValue)
                || x.Start.ToString("d/M/yy, h:mm a").ToLower().Contains(filterValue)
                || x.End.ToString("d/M/yy, h:mm a").ToLower().Contains(filterValue)
                ;
        }

        public override Expression<Func<Plan, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "name": return (x) => x.Name;
                case "laboratory.name": return (x) => x.Laboratory.Name;
                case "country.name": return (x) => x.Country.Name;
                case "start": return (x) => x.Start;
                case "end": return (x) => x.End;
                default: return (x) => x.Name;
            }
        }
    }
}
