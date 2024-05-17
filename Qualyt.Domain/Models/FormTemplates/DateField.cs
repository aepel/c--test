using Qualyt.Domain.Models.FormTemplates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.FormTemplates
{
    public class DateField:Field
    {
        public DateTimeOffset? Value { get; set; }
    }
}
