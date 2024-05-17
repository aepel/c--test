using Newtonsoft.Json;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.Mails;
using Qualyt.Domain.Models.Mails.Interfaces;
using Qualyt.Domain.Models.MedicalTreatments.Enums;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Qualyt.Domain.Models.MedicalTreatments
{
    public class Treatment : IAuditableEntity, IMaileable
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public bool Editable { get {
                return State != TreatmentState.Finalized;
            }
        }
        public Pathology Pathology { get; set; }
        public long PathologyId { get; set; }
        public Doctor Doctor { get; set; }
        public string DoctorId { get; set; }
        public Product Product { get; set; }
        public long ProductId { get; set; }
        public Patient Patient { get; set; }
        public long PatientId { get; set; }
        public TreatmentState State { get; set; }
        [NotMapped]
        public string StateName
        {
            get
            {
                return EnumHelper<TreatmentState>.GetDisplayValue(State);
            }
        }
        public TreatmentStateReason? StateReason { get; set; }
        [NotMapped]
        public string StateReasonName
        {
            get
            {
                return StateReason.HasValue? EnumHelper<TreatmentStateReason>.GetDisplayValue(StateReason.Value):"";
            }
        }
        public double Dose { get; set; }
        public double DoseFrequency { get; set; }
        public FrequencyType DoseFrequencyType { get; set; }
        [NotMapped]
        public string DoseFrequencyTypeName
        {
            get
            {
                return EnumHelper<FrequencyType>.GetDisplayValue(DoseFrequencyType);
            }
        }
        public double Duration { get; set; }
        public FrequencyType DurationType { get; set; }
        [NotMapped]
        public string DurationTypeName
        {
            get
            {
                return EnumHelper<FrequencyType>.GetDisplayValue(DurationType);
            }
        }
        public string Code {
            get
            {
                if(Pathology!=null && Product!=null && Patient!=null)
                    return Id.ToString()+Pathology.Name[0] + Product.Name[0] + Patient.Name[0] + Patient.Surname[0];
                return "";
            }
        }
        public virtual List<ControlTracking> ControlTrackings { get; set; }
        [NotMapped]
        public List<Field> PathologyFields { get; set; }
        public string SerializedPathologyFields
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                return JsonConvert.SerializeObject(PathologyFields, settings);
            }
            set
            {
                if (value != null)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };
                    PathologyFields = JsonConvert.DeserializeObject<List<Field>>(value, settings);
                }
            }
        }
        [NotMapped]
        public List<Field> ProductFields { get; set; }
        public string SerializedProductFields
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                return JsonConvert.SerializeObject(ProductFields, settings);
            }
            set
            {
                if (value != null)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };
                    ProductFields = JsonConvert.DeserializeObject<List<Field>>(value, settings);
                }
            }
        }

        public List<Tag> getTags()
        {
            return new List<Tag>
            {
                new Tag("{NEXT_CONTROL_DATE}", ControlTrackings.FirstOrDefault(y=>y.Id==ControlTrackings.Max(x=>x.Id))?.NextControl.Value.Date.ToLongDateString()),
                new Tag("{DOCTOR}", this.Doctor.FullName),
                new Tag("{ATTENTION_PLACE}", this.Doctor.AttentionPlace.Name)
            };
        }
    }
}
