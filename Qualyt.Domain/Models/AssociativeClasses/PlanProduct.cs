using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.AssociativeClasses
{
    public class PlanProduct
    {
        public long PlanId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
