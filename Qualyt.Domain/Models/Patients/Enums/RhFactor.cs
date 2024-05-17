using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Patients.Enums
{
    public enum RhFactor
    {
        [Display(Name = "Positivo")]
        Positive,
        [Display(Name = "Negativo")]
        Negative
    }
}
