using Microsoft.EntityFrameworkCore;
using Qualyt.Data;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models.Mails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IEmailTemplateService : IBaseService<EmailTemplate>
    {
        EmailTemplate GetTemplate(TipoEmailTemplate tipoEmailTemplate);
    }

    public class EmailTemplateService : BaseService<EmailTemplate>, IEmailTemplateService
    {

        public EmailTemplateService(IRepository<EmailTemplate> repo) : base(repo) { }

        public EmailTemplate GetTemplate(TipoEmailTemplate tipoEmailTemplate)
        {
            EmailTemplate emailTemplate = repo.Query().FirstOrDefault(x => x.TipoEmailTemplate == tipoEmailTemplate);
            return emailTemplate;
        }
    }

}
