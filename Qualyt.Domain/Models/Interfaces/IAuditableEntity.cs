using System;

namespace Qualyt.Domain.Models.Interfaces
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        bool Active { get; set; }
    }
}
