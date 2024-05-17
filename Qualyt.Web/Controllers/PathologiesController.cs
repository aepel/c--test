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
using Qualyt.Domain.Models.Stats;
using Qualyt.Services.Services;
using Qualyt.Web.Helpers;
using Qualyt.Web.ViewModels;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class PathologiesController : DatatableController<Pathology>
    {
        private IPathologiesService _service;
        public PathologiesController(IPathologiesService service):base(service.Query().Include(x=>x.Laboratory))
        {
            _service = service;
        }

        [HttpGet("[action]/{id}")]
        public List<Pathology> GetByPatient(long id)
        {
            return _service.GetByPatient(id);
        }

        [HttpPost("[action]")]
        public void Post([FromBody] PathologyViewModel value)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            var pathology = mapper.Map<Pathology>(value);
            _service.Add(pathology);
        }
        [HttpPost("[action]")]
        public long GetPathologiesCount([FromBody] DashboardFilter filter)
        { return _service.GetPathologiesCount(filter); }

        [HttpPost("[action]")]
        public long GetPathologiesCountLastMonth([FromBody] DashboardFilter filter)
        { return _service.GetPathologiesCountLastMonth(filter); }

        [HttpGet("[action]")]
        public IEnumerable<Pathology> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("[action]/{id}")]
        public Pathology Get(long id)
        {
            return _service.GetById(id);
        }

        [HttpPut("[action]")]
        public void Put([FromBody] PathologyViewModel value)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            var pathology = mapper.Map<Pathology>(value);
            _service.Update(pathology);
        }

        [HttpDelete("[action]/{id}")]
        public void Delete(long id)
        {
            _service.Remove(id);
        }

        public override Expression<Func<Pathology, bool>> Filter(string filterValue)
        {
            return (x) => 
                RemoveDiacritics(x.Name.ToLower()).Contains(filterValue)
                || RemoveDiacritics(x.Laboratory.Name.ToLower()).Contains(filterValue)
                ;
        }

        public override Expression<Func<Pathology, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                case "name": return (x) => x.Name;
                case "laboratory.name": return (x) => x.Laboratory.Name;
                default: return (x) => x.Name;
            }
        }
    }
}
