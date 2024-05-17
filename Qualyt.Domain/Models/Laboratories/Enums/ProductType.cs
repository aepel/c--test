using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Domain.Models.Laboratories.Enums
{
    public enum ProductType
    {
        [Display(Name ="Medicamento")]
        Medicine,
        [Display(Name = "Dispositivo")]
        Device
    }
}
