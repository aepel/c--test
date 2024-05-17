using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.FormTemplates
{
    public class OptionsField:Field
    {
        public List<Option> Options { get; set; }
    }
}
