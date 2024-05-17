using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.AssociativeClasses
{
    public class PlanPathology
    {
        public long PlanId { get; set; }
        public long PathologyId { get; set; }
        public Pathology Pathology { get; set; }
    }
}
