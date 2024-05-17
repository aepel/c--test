using Qualyt.Domain.Models.Laboratories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyt.Web.ViewModels
{
    public class PathologyViewModel
    {
        public long Id { get; set; }
        public long LaboratoryId { get; set; }
        public Laboratory Laboratory { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public List<FieldViewModel> Fields { get; set; }
    }
}
