
using Qualyt.Domain.Models.FormTemplates.Enums;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qualyt.Domain.Models.FormTemplates
{
    public class Field
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
        public FieldType Type { get; set; }
        [NotMapped]
        public string TypeName
        {
            get
            {
                return EnumHelper<FieldType>.GetDisplayValue(Type);
            }
        }
        public long? ParentId { get; set; }
    }
}