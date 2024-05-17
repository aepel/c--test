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
using Qualyt.Services.Services;
using Qualyt.Web.Helpers;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class ControlTrackingsController : CrudController<ControlTracking>
    {
        private IControlTrackingsService _service;
        public ControlTrackingsController(IControlTrackingsService service):base(service.Query().Include(x=>x.CreatedByUser),service)
        {
            _service = service;
        }

        [HttpPost("listwithotherparams")]
        public object ListWithOtherParams ([FromBody] ListParams p)
        {
            var queryParameters = p.queryParameters;
            var otherParams = p.otherParams;
            var treatmentId = otherParams.FirstOrDefault(x => x.Key == "treatmentId").Value;
            var _list = _query.Where(x => x.TreatmentId == (long)treatmentId).ToList();
            if (_list.Any())
            {
                var maxId = _list.Max(x => x.Id);
                var last = _list.FirstOrDefault(x => x.Id == maxId);
                _list.Remove(last);
                last.Editable = true;
                _list.Add(last);
            }
            _query = _list.AsQueryable();
            return base.List(queryParameters);
        }

        public override Expression<Func<ControlTracking, bool>> Filter(string filterValue)
        {   
            return (x) =>
                x.CreatedDate.ToString("d/M/yy, h:mm a").ToLower().Contains(filterValue)
                || (x.UpdatedDate.HasValue ? x.UpdatedDate.Value.ToString("d/M/yy, h:mm a").ToLower().Contains(filterValue) : "no aplica".Contains(filterValue))
                || (RemoveDiacritics(x.Comments.ToLower()).Contains(filterValue));
        }

        public override Expression<Func<ControlTracking, object>> OrderCondition(string propertyName)
        {
            switch (propertyName)
            {
                //case "active": return (x) => x.Active;
                case "createdDate": return (x) => x.CreatedDate;
                case "updatedDate": return (x) => x.UpdatedDate;
                case "comments"   : return (x) => x.Comments;
                default: return (x) => x.CreatedDate;
            }
        }
    }
}
