using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.AssociativeClasses
{
    public class UserCountry
    {
        public string UserId { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }
    }
}
