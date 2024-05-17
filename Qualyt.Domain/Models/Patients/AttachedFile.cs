using Qualyt.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Patients
{
    public class AttachedFile:IAuditableEntity
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public byte[] File { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public long? TermsAndConditionsId { get; set; }
        public TermsAndConditions TermsAndConditions { get; set; }
    }
}
