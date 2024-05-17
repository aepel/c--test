using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.MedicalTreatments.Enums
{
    public enum ControlType
    {
        [Display(Name = "Seguimiento")]
        Normal,
        [Display(Name = "Registro de inicio")]
        Start,
        [Display(Name = "Registro de fin")]
        End
    }
}
