using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Patients.Enums
{
    public enum PatientState
    {
        [Display(Name = "Preinscrito")]
        Preregistered,
        [Display(Name = "Inscrito")]
        Registered
    }
}
