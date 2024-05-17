using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.AssociativeClasses
{
    public class PatientTermsAndConditions
    {
        public long PatientId { get; set; }
        public long TermsAndConditionsId { get; set; }
        public TermsAndConditions TermsAndConditions { get; set; }
    }
}
