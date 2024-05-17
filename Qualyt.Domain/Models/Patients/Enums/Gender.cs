using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Patients.Enums
{
    public enum Gender
    {
        [Display(Name = "Masculino")]
        Male,
        [Display(Name = "Femenino")]
        Female
    }
}
