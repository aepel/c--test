using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyt.Web.ViewModels
{
    public class HealthInsuranceViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public long? CountryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public List<FieldViewModel> Fields { get; set; }
    }
}
