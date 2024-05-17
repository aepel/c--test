using Qualyt.Domain.Models.Mails;
using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Mails
{
    public class TagsFactory
    {
        public static List<string> GetTags(TipoEmailTemplate tipo) {
            List<string> tags = new List<string>();
            IMaileableTagNames tag = null;
            switch (tipo)
            {
                case TipoEmailTemplate.TermsAndConditionsAcceptance:
                    tag = new TermsAndConditionsAcceptanceTag();
                    break;
            }

            if (tag != null)
                tags = tag.getTagNames();

            DatosTag datosTag = new DatosTag();
            tags.AddRange(datosTag.getTagNames());

            return tags;
        }
    }
}
