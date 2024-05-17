using Qualyt.Domain.Models.MedicalTreatments;
using System;
using System.Collections.Generic;

namespace Qualyt.Domain.Models.Stats
{
    public class DashboardFilter
    {
        public DashboardFilter()
        {
            SelectedPlanIds = new List<long>();
        }
        public DateTimeOffset? Start { get; set; }
        public DateTimeOffset? End { get; set; }
        public List<long> SelectedPlanIds { get; set; }
    }
}
