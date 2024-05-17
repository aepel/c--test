using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Patients.Enums
{
    public enum BloodType
    {
        [Display(Name = "A")]
        A,
        [Display(Name = "B")]
        B,
        [Display(Name = "AB")]
        AB,
        [Display(Name = "O")]
        O
    }
}
