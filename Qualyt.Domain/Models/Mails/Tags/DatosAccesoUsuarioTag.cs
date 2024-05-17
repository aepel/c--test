
using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Mails
{
    public class DatosAccesoUsuarioTag : IMaileableTagNames
    {
        public static readonly string USUARIO_NOMBRE = "{USUARIO_NOMBRE}";
        public static readonly string USUARIO_USERNAME = "{USUARIO_USERNAME}";
        public static readonly string USUARIO_CONTRASENA = "{USUARIO_CONTRASENA}";

        public List<string> getTagNames()
        {
            List<String> tagsName = new List<String>();

            tagsName.Add(USUARIO_NOMBRE);
            tagsName.Add(USUARIO_USERNAME);
            tagsName.Add(USUARIO_CONTRASENA);

            return tagsName;
        }
    }
}
