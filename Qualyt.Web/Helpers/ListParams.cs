using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyt.Web.Helpers
{
    public class ListParams
    {
        public QueryParameters queryParameters { get; set; }
        public List<KeyValue> otherParams { get; set; }
    }
}
