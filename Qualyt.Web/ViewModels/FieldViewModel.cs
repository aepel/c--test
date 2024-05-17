
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.FormTemplates.Enums;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qualyt.Web.ViewModels
{
    public class FieldViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
        public FieldType Type { get; set; }
        public object Value { get; set; }
        public List<Option> Options { get; set; }
        public long? Minimum { get; set; }
        public long? Maximum { get; set; }
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