using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.MedicalTreatments.Enums
{
    public enum FrequencyType
    {
        [Display(Name = "Minutos")]
        Minutes,
        [Display(Name = "Horas")]
        Hours,
        [Display(Name = "Días")]
        Days,
        [Display(Name = "Semanas")]
        Weeks,
        [Display(Name = "Meses")]
        Months
    }
}
