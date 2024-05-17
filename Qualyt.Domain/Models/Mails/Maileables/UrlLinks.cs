using Qualyt.Domain.Models.Mails;
using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;

namespace Qualyt.Domain.Models.Mails.Maileables
{
    //public interface IUrlLinks : IMaileable {

    //}
    public class UrlLinks : IMaileable
    {
        public string UrlTermsAndConditionsAcceptance { get; set; }
        
        public UrlLinks()
        {
            
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
            tags.Add(new Tag(ConfirmacionDeUsuarioYDatosAccesoUsuarioTag.URL_TERMS_AND_CONDITIONS_ACCEPTANCE, UrlTermsAndConditionsAcceptance));
            return tags;
        }
    }
}
