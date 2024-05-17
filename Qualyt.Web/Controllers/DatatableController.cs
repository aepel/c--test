using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qualyt.Services;
using Qualyt.Web.Helpers;

namespace Qualyt.Web.Controllers
{
    public abstract class DatatableController<T> : ControllerBase where T : class
    {
        public DatatableController(IQueryable<T> queryable)
        {
            _query = queryable;
        }
        public IQueryable<T> _query;

        public abstract Expression<Func<T, bool>> Filter(string filterValue);
        public abstract Expression<Func<T, object>> OrderCondition(string propertyName);

        [HttpPost("list")]
        public virtual object List([FromBody] QueryParameters queryParameters)
        {
            IQueryable<T> query;
            long count=_query.Count();
            if (!String.IsNullOrWhiteSpace(queryParameters.OrderColumnName))
            {
                if (queryParameters.Asc)
                    query = _query.OrderBy(OrderCondition(queryParameters.OrderColumnName));
                else
                    query = _query.OrderByDescending(OrderCondition(queryParameters.OrderColumnName));
            }
            else
                query = _query;
            if (!String.IsNullOrWhiteSpace(queryParameters.FilterValue))
            {
                query = query.Where(Filter(RemoveDiacritics(queryParameters.FilterValue.ToLower())));
                count=query.Count();
            }
            var list = query.ToList();
            return new
            {
                list = query.Skip(queryParameters.PageSize * (queryParameters.PageNumber - 1))
                .Take(queryParameters.PageSize)
                .ToList(),
                totalCount = count
            }; 
        }

        public string RemoveDiacritics(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

    }

}