using Newtonsoft.Json;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories.Enums;
using Qualyt.Domain.Models.MedicalTreatments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qualyt.Domain.Models.Laboratories
{
    public class Device:Product
    {
        public string DeviceType { get; set; }
    }
}
