using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Mails
{
    public class DatosTag : IMaileableTagNames
    {
        public static readonly string DATOS_FECHA = "{DATOS_FECHA}";
        public static readonly string DATOS_FECHAHORA = "{DATOS_FECHAHORA}";
        public static readonly string DATOS_DOMINIO = "{DATOS_DOMINIO}";

        public List<string> getTagNames()
        {
            List<String> tagsName = new List<String>();

            tagsName.Add(DATOS_FECHA);
            tagsName.Add(DATOS_FECHAHORA);
            tagsName.Add(DATOS_DOMINIO);

            return tagsName;
        }
    }
}
