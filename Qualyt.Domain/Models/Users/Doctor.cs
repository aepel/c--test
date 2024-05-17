using Microsoft.AspNetCore.Identity;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qualyt.Domain.Models.Users
{
    public class Doctor : ApplicationUser
    {
        public string IdNumber { get; set; }
        public AttentionPlace AttentionPlace { get; set; }
        public Location Location { get; set; }
        public long AttentionPlaceId { get; set; }
        public Country Country { get; set; }
        public long CountryId { get; set; }
        public SalesContact SalesContact { get; set; }
        public long SalesContactId { get; set; }
        public string CellPhoneNumber { get; set; }
        public string FullNameAndSpecialty
        {
            get
            {
                return FullName + " - " + (Specialty?.Name??"");
            }
        }
        public virtual DoctorSpecialty Specialty { get; set; }
        public long SpecialtyId { get; set; }
        public List <HealthInsuranceDoctor> HealthInsuranceDoctors { get; set; }

        
    }
}
