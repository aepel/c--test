using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.Laboratories.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Qualyt.Web.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public ProductType ProductType { get; set; }
        public long LaboratoryId { get; set; }
        public Laboratory Laboratory { get; set; }
        public long Amount { get; set; }
        public string Code
        {
            get
            {
                return Name[0] + (Name.Length > 1 ? Name[1].ToString() : "") + Id.ToString();
            }
        }
        [NotMapped]
        public List<FieldViewModel> Fields { get; set; }
        public string DeviceType { get; set; }
        public DosageForm Form { get; set; }
        public double Variation { get; set; }
        public VariationUnit VariationUnit { get; set; }
        public string DefinedDailyDose { get; set; }
        public string ActiveSubstance { get; set; }
    }
}
