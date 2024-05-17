using Newtonsoft.Json;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments.Enums;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Domain.Models.MedicalTreatments
{
    public class Plan : IAuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long LaboratoryId { get; set; }
        public Laboratory Laboratory { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public List<PlanPathology> PlanPathologies { get; set; }
        public List<PlanProduct> PlanProducts { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
    }
}
