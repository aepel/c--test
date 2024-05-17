using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Users
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string IdPattern { get; set; }
        public int? DigitsOfACellPhoneNumber { get; set; }
    }
}
