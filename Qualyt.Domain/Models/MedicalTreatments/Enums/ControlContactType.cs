using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.MedicalTreatments.Enums
{
    public enum ControlContactType
    {
        [Display(Name = "Llamada")]
        Call,
        [Display(Name = "Mail")]
        Mail,
        [Display(Name = "SMS")]
        SMS,
        [Display(Name = "WhatsApp")]
        WhatsApp,
        [Display(Name = "Visita de enfermera")]
        NurseVisit,
        [Display(Name = "Evento adverso")]
        AdverseEvent
    }
}
