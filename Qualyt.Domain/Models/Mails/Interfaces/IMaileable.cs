using Qualyt.Domain.Models.Mails;
using System.Collections.Generic;

namespace Qualyt.Domain.Models.Mails.Interfaces
{
    public interface IMaileable
    {
        List<Tag> getTags();
    }
}
