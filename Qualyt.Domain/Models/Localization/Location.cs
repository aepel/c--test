using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Localization
{
    public class Location
    {
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Floor { get; set; }
        public string Apartment { get; set; }
    }
}
