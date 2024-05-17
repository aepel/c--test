using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Patients.Enums
{
    public enum BirthsType
    {
        [Display(Name = "Parto")]
        Parturition,
        [Display(Name = "Cesárea")]
        CaesareanOperation,
        [Display(Name = "Ambos")]
        Both
    }
}
