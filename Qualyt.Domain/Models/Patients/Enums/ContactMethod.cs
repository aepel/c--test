using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Patients.Enums
{
    public enum ContactMethod
    {
        [Display(Name = "Mail")]
        Mail,
        [Display(Name = "Teléfono")]
        Phone
    }
}
