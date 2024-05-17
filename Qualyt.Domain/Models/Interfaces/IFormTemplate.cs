using Qualyt.Domain.Models.FormTemplates;
using System.Collections.Generic;

namespace Qualyt.Domain.Models.Interfaces
{
    public interface IFormTemplate
    {
        List<Field> Fields { get; set; }
        string SerializedFields { get; set; }
    }
}
