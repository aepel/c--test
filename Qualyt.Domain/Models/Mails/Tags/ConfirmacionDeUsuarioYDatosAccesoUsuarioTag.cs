
using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Mails
{
    class ConfirmacionDeUsuarioYDatosAccesoUsuarioTag : IMaileableTagNames
    {
        public static readonly string URL_TERMS_AND_CONDITIONS_ACCEPTANCE = "{URL_TERMS_AND_CONDITIONS_ACCEPTANCE}";

        public List<string> getTagNames()
        {
            List<String> tagsName = new List<String>();

            tagsName.Add(URL_TERMS_AND_CONDITIONS_ACCEPTANCE);

            return tagsName;
        }
    }
}
