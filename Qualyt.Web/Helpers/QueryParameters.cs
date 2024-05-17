using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyt.Web.Helpers
{
    public class QueryParameters
    {
        public bool Asc { get; set; }
        public string OrderColumnName { get; set; }
        public string FilterValue { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class KeyValue
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
