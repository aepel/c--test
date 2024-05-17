using Microsoft.Extensions.Options;
using Qualyt.Domain.Models.Mails;
using Qualyt.Domain.Models.Mails.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Mails
{
    //public interface IEmailBuilder {
    //    EmailBuilder SetRemitente(string from);
    //    EmailBuilder AddDestino(string to);
    //    EmailBuilder SetTemplate(EmailTemplate template);
    //    EmailBuilder AddElementoSubject(IMaileable elemento);
    //    EmailBuilder AddElementoBody(IMaileable elemento)
    //}
    public class EmailBuilder
    {
        protected string from;
        protected List<string> to;
        protected string subject;
        protected string body;
        protected Email email;
        protected EmailTemplate template;
        protected List<IMaileable> elementosSubject;
        protected List<IMaileable> elementosBody;

        public EmailBuilder() {
            email = new Email();
            elementosSubject = new List<IMaileable>();
            elementosBody = new List<IMaileable>();
            to = new List<string>();
        }

        public EmailBuilder(IDatos datos) : this()
        {
            elementosSubject.Add(datos);
            elementosBody.Add(datos);
        }

        public void SetRemitente(string from)
        {
            this.from = from;
        }

        public void AddDestino(string to)
        {
            this.to.Add(to);
        }

        public void SetTemplate(EmailTemplate template)
        {
            this.template = template;
        }

        public void AddElementoSubject(IMaileable elemento)
        {
            if (!elementosSubject.Contains(elemento))
                elementosSubject.Add(elemento);
        }

        public void AddElementoGlobal(IMaileable elemento) {
            AddElementoBody(elemento);
            AddElementoSubject(elemento);
        }

        public void AddElementoBody(IMaileable elemento)
        {
            if (!elementosBody.Contains(elemento))
                elementosBody.Add(elemento);
        }

        public void AddElementoBodyList(List<IMaileable> elementoList)
        {
            foreach (var item in elementoList)
            {
            if (!elementosBody.Contains(item))
                    elementosBody.Add(item);
            }
        }
        public void AddElementoSubjectList(List<IMaileable> elementoList)
        {
            foreach (var item in elementoList)
            {
                if (!elementosSubject.Contains(item))
                    elementosSubject.Add(item);

            }
        }
        public Email Build()
        {
            email.From = from;
            email.To = to;
            email.Subject = crearSubject();
            email.Body = crearBody();
            
            return email;
        }

        private string crearSubject()
        {
            this.subject = template.Subject;

            List<Tag> allTagsElementosSubject = getAllTagsDeElementosSubject();

            foreach (Tag emailtag in template.getTagsFromSubject())
            {
                if (allTagsElementosSubject.Contains(emailtag)) {
                    emailtag.Value = allTagsElementosSubject.Find(item => item.Key == emailtag.Key).Value;
                    subject = emailtag.ReemplazarTag(subject);
                }
                    //throw new EmailTagNotFoundException(emailtag.Key);
            }

            return subject;
        }

        private string crearBody()
        {
            this.body = template.Body;

            List<Tag> allTagsElementosBody = getAllTagsDeElementosBody();

            foreach (Tag emailtag in template.getTagsFromBody())
            {
                if (allTagsElementosBody.Contains(emailtag)) {
                    emailtag.Value = allTagsElementosBody.Find(item => item.Key == emailtag.Key).Value;
                    body = emailtag.ReemplazarTag(body);
                }
                    //throw new EmailTagNotFoundException(emailtag.Key);

            }

            return body;
        }

        protected List<Tag> getAllTagsDeElementosSubject()
        {
            List<Tag> tags = new List<Tag>();
            foreach (IMaileable elemento in elementosSubject)
            {
                tags.AddRange(elemento.getTags());
            }

            return tags;
        }

        protected List<Tag> getAllTagsDeElementosBody()
        {
            List<Tag> tags = new List<Tag>();
            foreach (IMaileable elemento in elementosBody)
            {
                tags.AddRange(elemento.getTags());
            }

            return tags;
        }
    }
}
