using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Laboratories.Enums
{
    public enum DosageForm
    {
        [Display(Name = "Comprimido")]
        Tablet,
        [Display(Name = "Cápsula")]
        Capsule,
        [Display(Name = "Óvulo")]
        VaginalCapsule,
        [Display(Name = "Polvo")]
        Powder,
        [Display(Name = "Jarabe")]
        Syrup,
        [Display(Name = "Suspensión")]
        OralSuspension,
        [Display(Name = "Solución")]
        OralSolution,
        [Display(Name = "Supositorio")]
        Suppository,
        [Display(Name = "Gota")]
        EyeDrop,
        [Display(Name = "Colirio")]
        Collyrium
    }
}
