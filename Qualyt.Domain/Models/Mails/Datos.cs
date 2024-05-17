using Microsoft.Extensions.Options;
using Qualyt.Domain.Models.Mails.Config;
using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyt.Domain.Models.Mails
{
    public interface IDatos : IMaileable
    {
    }
    public class Datos : IDatos
    {
        public static string dominio;
        public Datos(IOptions<DatosTagSettings> options)
        {
            dominio = options.Value.Domain;
        }
        public static DateTimeOffset Fecha
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }

        public List<Tag> getTags()
        {
            List<Tag> tags = new List<Tag>();
            tags.Add(new Tag(DatosTag.DATOS_FECHA, Fecha.ToString("dd/MM/yyyy")));
            tags.Add(new Tag(DatosTag.DATOS_FECHAHORA, Fecha.ToString("dd/MM/yyyy HH:mm")));
            tags.Add(new Tag(DatosTag.DATOS_DOMINIO, dominio));

            return tags;
        }
    }
}
