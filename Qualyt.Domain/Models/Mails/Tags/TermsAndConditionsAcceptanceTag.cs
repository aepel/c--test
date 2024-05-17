using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Mails
{
    public class TermsAndConditionsAcceptanceTag : IMaileableTagNames
    {
        public static readonly string URL_ACCEPTANCE = "{URL_ACCEPTANCE}";

        public TermsAndConditionsAcceptanceTag()
        {
        }

        public List<string> getTagNames()
        {
            List<String> tagsName = new List<String>();
            
            tagsName.Add(URL_ACCEPTANCE);

            return tagsName;
        }
    }
}
