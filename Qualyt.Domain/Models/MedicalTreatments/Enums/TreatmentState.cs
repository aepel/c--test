using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.MedicalTreatments.Enums
{
    public enum TreatmentState
    {
        [Display(Name = "Pendiente")]
        Pending,
        [Display(Name = "En tratamiento")]
        InTreatment,
        [Display(Name = "Suspendido")]
        Suspended,
        [Display(Name = "Finalizado")]
        Finalized
    }
}
