using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.AssociativeClasses
{
    public class HealthInsuranceDoctor
    {
        public long HealthInsuranceId { get; set; }
        public HealthInsurance HealthInsurance { get; set; }
        public string DoctorId { get; set; }
    }
}
