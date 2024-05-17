using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Domain.Models.Laboratories
{
    public class Laboratory:IAuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public string Color { get; set; }
        public byte[] IconBytes { get; set; }
        public string IconType { get; set; }
    }
}
