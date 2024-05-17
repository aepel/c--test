using Newtonsoft.Json;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Domain.Models.HealthInsurances
{
    public class HealthInsurance:IAuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public long? CountryId { get; set; }
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
