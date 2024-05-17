
using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Mails
{
    public class UsuariosTags : IMaileableTagNames
    {
        public static readonly string USUARIO_NOMBRE = "{USUARIO_NOMBRE}";
        public static readonly string USUARIO_EMAIL = "{USUARIO_EMAIL}";
        public static readonly string USUARIO_PASSWORD = "{USUARIO_PASSWORD}";


        public List<string> getTagNames()
        {
            List<String> tagsName = new List<String>();

            tagsName.Add(USUARIO_NOMBRE);
            tagsName.Add(USUARIO_EMAIL);
            tagsName.Add(USUARIO_PASSWORD);
            return tagsName;
        }
    }
}
