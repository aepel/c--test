using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Mails
{
    public class ChangePasswordModel : IMaileable
    {
        public String PasswordTemporal { get; set; }
        public List<Tag> getTags()
        {
            List<Tag> tags = new List<Tag>();
            tags.Add(new Tag("{TEMPORAL}", this.PasswordTemporal));
            return tags;
        }
    }
}
