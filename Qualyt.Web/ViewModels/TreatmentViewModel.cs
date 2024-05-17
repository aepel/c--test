using Newtonsoft.Json;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.MedicalTreatments.Enums;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using Qualyt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Web.ViewModels
{
    public class TreatmentViewModel : IAuditableEntity
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public Pathology Pathology { get; set; }
        public long PathologyId { get; set; }
        public Doctor Doctor { get; set; }
        public string DoctorId { get; set; }
        public Product Product { get; set; }
        public long ProductId { get; set; }
        public Patient Patient { get; set; }
        public long PatientId { get; set; }
        public TreatmentState State { get; set; }
        public TreatmentStateReason? StateReason { get; set; }
        public double Dose { get; set; }
        public double DoseFrequency { get; set; }
        public FrequencyType DoseFrequencyType { get; set; }
        public double Duration { get; set; }
        public FrequencyType DurationType { get; set; }
        public List<ControlTracking> ControlTrackings { get; set; }
        public List<FieldViewModel> PathologyFields { get; set; }
        public List<FieldViewModel> ProductFields { get; set; }
    }
}
