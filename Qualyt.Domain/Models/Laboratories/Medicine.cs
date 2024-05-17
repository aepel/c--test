using Newtonsoft.Json;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories.Enums;
using Qualyt.Domain.Models.MedicalTreatments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Domain.Models.Laboratories
{
    public class Medicine:Product
    {
        public DosageForm Form { get; set; }
        public double Variation { get; set; }
        public VariationUnit VariationUnit { get; set; }
        public string DefinedDailyDose { get; set; }
        public string ActiveSubstance { get; set; }
    }
}
