using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Domain.Models.Laboratories.Enums
{
    public enum DeviceType
    {
        [Display(Name ="Un tipo")]
        Type1,
        [Display(Name = "Otro tipo")]
        Type2
    }
}
