using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Patients.Enums
{
    public enum MaritalStatus
    {
        [Display(Name = "Soltero")]
        Single,
        [Display(Name = "Divorciado")]
        Divorced,
        [Display(Name = "Viudo")]
        Widowed,
        [Display(Name = "Separado")]
        Separated,
        [Display(Name = "Casado")]
        Married
    }
}
