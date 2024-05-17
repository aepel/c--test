using Qualyt.Domain.Models.FormTemplates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.FormTemplates
{
    public class NumericField:Field
    {
        public double? Value { get; set; }
        public double? Minimum { get; set; }
        public double? Maximum { get; set; }
    }
}
