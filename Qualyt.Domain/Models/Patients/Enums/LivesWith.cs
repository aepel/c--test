using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Patients.Enums
{
    public enum LivesWith
    {
        [Display(Name = "Solo")]
        Alone,
        [Display(Name = "Padres")]
        Parents,
        [Display(Name = "Conyuge")]
        Spouse,
        [Display(Name = "Conyuge e hijos")]
        SpouseAndChildren,
        [Display(Name = "Hijos")]
        Children,
        [Display(Name = "Otros")]
        Others
    }
}
