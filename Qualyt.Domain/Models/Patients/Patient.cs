using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Localization;
using Qualyt.Domain.Models.Mails;
using Qualyt.Domain.Models.Mails.Interfaces;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients.Enums;
using Qualyt.Domain.Models.Users;

namespace Qualyt.Domain.Models.Patients
{
    public class Patient : IAuditableEntity, IMaileable
    {
        public Patient()
        {

        }
        public Patient(Patient ent)
        {
            AcceptedTerms = ent.AcceptedTerms;
            Active = ent.Active;
            BirthDate = ent.BirthDate;
            CardNumber = ent.CardNumber;
            CellPhoneNumber = ent.CellPhoneNumber;
            Country = ent.Country;
            CountryId = ent.CountryId;
            CreatedBy = ent.CreatedBy;
            CreatedDate = ent.CreatedDate;
            Doctor = ent.Doctor;
            DoctorId = ent.DoctorId;
            Email = ent.Email;
            Gender = ent.Gender;
            HealthInsurance = ent.HealthInsurance;
            HealthInsuranceId = ent.HealthInsuranceId;
            Id = ent.Id;
            IdNumber = ent.IdNumber;
            Location = ent.Location;
            MaritalStatus = ent.MaritalStatus;
            MothersSurname = ent.MothersSurname;
            Name = ent.Name;
            PatientPathologies = ent.PatientPathologies;
            PatientTermsAndConditions = ent.PatientTermsAndConditions;
            PhoneNumber = ent.PhoneNumber;
            Plan = ent.Plan;
            PlanId = ent.PlanId;
            PreferedContactMethod = ent.PreferedContactMethod;
            SecondHealthInsurance = ent.SecondHealthInsurance;
            Surname = ent.Surname;
            State = ent.State;
            UpdatedBy = ent.UpdatedBy;
            UpdatedDate = ent.UpdatedDate;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MothersSurname { get; set; }
        public string FullName
        {
            get
            {
                return Name + " " + Surname + " " + MothersSurname;
            }
        }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public virtual List<PatientTermsAndConditions> PatientTermsAndConditions { get; set; }
        [NotMapped]
        public bool LastTermsAccepted { get; set; }
        public virtual List<PatientPathology> PatientPathologies { get; set; }
        public virtual HealthInsurance HealthInsurance { get; set; }
        public long HealthInsuranceId { get; set; }
        public bool SecondHealthInsurance { get; set; }
        public string Code { get
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
        [NotMapped]
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
        public PatientState State { get; set; }
        public string StateName { get {  return EnumHelper<PatientState>.GetDisplayValue(State); } }
        public string CardNumber { get;set;}
        public string Email { get; set; }
        [NotMapped]
        public string MaritalStatusName
        {
            get
            {
                return EnumHelper<MaritalStatus>.GetDisplayValue(MaritalStatus);
            }
        }
        public virtual Location Location {get;set; }
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public long PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
        public long? NurseId { get; set; }
        public virtual Nurse Nurse { get; set; }
        public ContactMethod PreferedContactMethod { get; set; }
        public bool EmailSended { get; set; }
        [NotMapped]
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
        public ClinicalHistory ClinicalHistory { get; set; }

        [NotMapped]
        public List<Field> HealthInsuranceFields { get; set; }
        public string SerializedHealthInsuranceFields
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                return JsonConvert.SerializeObject(HealthInsuranceFields, settings);
            }
            set
            {
                if (value != null)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };
                    HealthInsuranceFields = JsonConvert.DeserializeObject<List<Field>>(value, settings);
                }
            }
        }
        public List<Tag> getTags()
        {
            return new List<Tag>
            {
                new Tag("{NAME}", this.Name),
                new Tag("{SURNAME}", this.Surname),
                new Tag("{PLAN}", this.Plan.Name),
                new Tag("{FULLNAME}", this.FullName)
            };
        }
    }
}
