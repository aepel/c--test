using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.MedicalTreatments.Enums;
using Qualyt.Domain.Models.Patients.Enums;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Domain.Models.MedicalTreatments
{
    public class ControlTracking:IAuditableEntity
    {
        public ControlTracking()
        {
            Editable = false;
        }
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? NextControl { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public bool? FollowingTheTreatment { get; set; }
        public DateTimeOffset? NextDoctorVisit { get; set; }
        public DateTimeOffset? TreatmentStart { get; set; }
        public DateTimeOffset? NextTreatment { get; set; }
        public string TreatmentInterruptReason { get; set; }
        public DateTimeOffset? TreatmentInterruptDate { get; set; }
        public string Comments { get; set; }
        public long TreatmentId { get; set; }
        public ControlContactType ContactMethod { get; set; }
        public ControlType Type { get; set; }
        [NotMapped]
        public string ContactMethodName
        {
            get
            {
                return EnumHelper<ControlContactType>.GetDisplayValue(ContactMethod);
            }
        }
        [NotMapped]
        public bool Editable { get; set; }
        public bool EditableByOperator
        {
            get
            {
                return CreatedDate.AddHours(1) >= DateTime.Now;
            }
        }
        public bool StartRegister
        {
            get
            {
                return Type==ControlType.Start;
            }
        }
        public bool EndRegister
        {
            get
            {
                return Type==ControlType.End;
            }
        }
    }
}
