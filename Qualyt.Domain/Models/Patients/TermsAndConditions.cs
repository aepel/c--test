using Qualyt.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Patients
{
    public class TermsAndConditions
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset? PublishedDate { get; set; }
        public string PublishedBy { get; set; }
        public long? Version { get; set; }
        public bool Published { get; set; }
        public bool Active { get; set; }
        public bool Publishable { get => (!Published && !Active); }
        public bool Deletable { get => !Published; }
    }
}
