using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Laboratories.Enums
{
    public enum VariationUnit
    {
        [Display(Name = "mg")]
        Milligram,
        [Display(Name = "g")]
        Gram,
        [Display(Name = "ml")]
        Milliliter,
        [Display(Name = "l")]
        Liter,
        [Display(Name = "mg/ml")]
        MilligramsPerMilliliter,
        [Display(Name = "g/l")]
        GramsPerLiter,
        [Display(Name = "mg/100ml")]
        MilligramsPer100Milliliters
    }
}
