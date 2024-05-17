using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.AssociativeClasses
{
    public class UserPlan
    {
        public string UserId { get; set; }
        public long PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
