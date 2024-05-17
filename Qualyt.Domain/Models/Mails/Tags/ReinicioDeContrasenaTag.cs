
using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Mails
{
    public class ReinicioDeContrasenaTag : IMaileableTagNames
    {
        public static readonly string NOMBRE_REINICIO_CONTRASENA = "{NOMBRE_REINICIO_CONTRASENA}";
        public static readonly string URL_RESET_PASSWORD = "{URL_RESET_PASSWORD}";

        public ReinicioDeContrasenaTag()
        {
        }

        public List<string> getTagNames()
        {
            List<String> tagsName = new List<String>();

            tagsName.Add(NOMBRE_REINICIO_CONTRASENA);
            tagsName.Add(URL_RESET_PASSWORD);

            return tagsName;
        }
    }
}
