using Newtonsoft.Json;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Domain.Models.MedicalTreatments
{
    public class Pathology:IAuditableEntity,IFormTemplate
    {
        public long Id { get; set; }
        public long LaboratoryId { get; set; }
        public Laboratory Laboratory { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        [NotMapped]
        public List<Field> Fields { get; set; }
        public string SerializedFields
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                return JsonConvert.SerializeObject(Fields, settings);
            }
            set
            {
                if (value != null)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };
                    Fields = JsonConvert.DeserializeObject<List<Field>>(value, settings);
                }
            }
        }
    }
}
