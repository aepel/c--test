using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Patients.Enums;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyt.Web.ViewModels
{
    public class PatientViewModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MothersSurname { get; set; }
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public virtual List<PatientTermsAndConditions> PatientTermsAndConditions { get; set; }
        public bool LastTermsAccepted { get; set; }
        public virtual List<PatientPathology> PatientPathologies { get; set; }
        public virtual HealthInsuranceViewModel HealthInsurance { get; set; }
        public virtual ClinicalHistory ClinicalHistory { get; set; }
        public long HealthInsuranceId { get; set; }
        public bool SecondHealthInsurance { get; set; }
        public string Code
        {
            get
            {
                try
                {
                    return "" + Name[0] + Name[1] + Surname[0] + Surname[1] + Id.ToString();
                }
                catch
                {
                    try
                    {
                        return "" + Name[0] + Surname[0] + Surname[1] + Id.ToString();
                    }
                    catch
                    {
                        try
                        {
                            return "" + Name[0] + Name[1] + Surname[0] + Id.ToString();
                        }
                        catch
                        {

                            return "" + Name[0] + Surname[0] + Id.ToString();
                        }
                    }
                }
            }
        }
        public bool Active { get; set; }
        public Gender Gender { get; set; }
        public string GenderName
        {
            get
            {
                return EnumHelper<Gender>.GetDisplayValue(Gender);
            }
        }
        // DNI, RUT, etc...
        public string IdNumber { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
        public string MaritalStatusName
        {
            get
            {
                return EnumHelper<MaritalStatus>.GetDisplayValue(MaritalStatus);
            }
        }
        public Domain.Models.Localization.Location Location { get; set; }
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public long PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
        public long? NurseId { get; set; }
        public virtual Nurse Nurse { get; set; }
        public ContactMethod PreferedContactMethod { get; set; }
        public string PreferedContactMethodName
        {
            get
            {
                return EnumHelper<ContactMethod>.GetDisplayValue(PreferedContactMethod);
            }
        }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public virtual List<AttachedFile> AcceptedTerms { get; set; }
        public List<FieldViewModel> HealthInsuranceFields { get; set; }
        public bool EmailSended { get; set; }
    }
}
