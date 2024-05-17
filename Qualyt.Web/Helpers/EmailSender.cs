using MailKit.Net.Smtp;
using MimeKit;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Microsoft.Extensions.Options;
using Qualyt.Domain.Models.Mails;
using System.Net;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Mails.Interfaces;
using System.Collections.Generic;
using Qualyt.Services.Services;
using Qualyt.Domain.Models.Mails.Maileables;
using System.Security.Cryptography;
using System.Web;
using Qualyt.Domain.Models.MedicalTreatments;

namespace Qualyt.Web.Helpers
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Email email);
        Task SendTermsAndConditionsMailAsync(Patient Patient, IUrlHelper urlHelper);
        Task<(bool success, string errorMsg)> SendEmailAsync(MailboxAddress sender, MailboxAddress[] recepients, string subject, string body, SmtpConfig config = null, bool isHtml = true);
        Task<(bool success, string errorMsg)> SendEmailAsync(string recepientName, string recepientEmail, string subject, string body, SmtpConfig config = null, bool isHtml = true);
        Task<(bool success, string errorMsg)> SendEmailAsync(string senderName, string senderEmail, string recepientName, string recepientEmail, string subject, string body, SmtpConfig config = null, bool isHtml = true);
        void SendNotifyTomorrowControlsMailAsync(List<Treatment> treatments);
        string GetEmailToReceive();
    }



    public class EmailSender : IEmailSender
    {
        private SmtpConfig _config;
        private ApplicationUrls _appUrls;
        IEmailTemplateService _emailTemplateService;
        IPlansService _plansService;
        private IDatos _datos;

        public EmailSender(IOptions<ApplicationUrls> appUrls, IOptions<SmtpConfig> config, IEmailTemplateService emailTemplateService,
            IDatos datos, IPlansService plansService)
        {
            _config = config.Value;
            _appUrls = appUrls.Value;
            _emailTemplateService = emailTemplateService;
            _datos = datos;
            _plansService = plansService;
        }

        public async Task SendTermsAndConditionsMailAsync(Patient Patient, IUrlHelper urlHelper)
        {

            MD5 hs = MD5.Create();
            byte[] db = hs.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Patient.Id.ToString()));
            string result = Convert.ToBase64String(db);
            var callbackUrl = urlHelper.EmailConfirmationLink(HttpUtility.UrlEncode(result), Patient.Id.ToString(),_appUrls.TermsAndConditionsAcceptance);

            List<IMaileable> elementosBody = new List<IMaileable>();
            List<IMaileable> elementosSubject = new List<IMaileable>();
            EmailTemplate template = this._emailTemplateService.GetTemplate(TipoEmailTemplate.TermsAndConditionsAcceptance);
            EmailBuilder emailBuilder = new EmailBuilder(_datos);
            Patient.Plan = _plansService.GetById(Patient.PlanId);
            UrlLinks urlLinks = new UrlLinks
            {
                UrlTermsAndConditionsAcceptance = callbackUrl
            };
            emailBuilder.AddDestino(Patient.Email);
            emailBuilder.SetTemplate(template);
            emailBuilder.AddElementoSubject(Patient);
            emailBuilder.AddElementoBody(Patient);
            emailBuilder.AddElementoSubject(urlLinks);
            emailBuilder.AddElementoBody(urlLinks);
            emailBuilder.AddElementoSubject(_config);
            emailBuilder.AddElementoBody(_config);
            Email email = emailBuilder.Build();

            await SendEmailAsync(email);
        }

        public async Task<(bool success, string errorMsg)> SendEmailAsync(
            string recepientName,
            string recepientEmail,
            string subject,
            string body,
            SmtpConfig config = null,
            bool isHtml = true)
        {
            var from = new MailboxAddress(_config.EmailAddressToSend, _config.EmailAddressToSend);
            var to = new MailboxAddress(recepientName, recepientEmail);

            return await SendEmailAsync(from, new MailboxAddress[] { to }, subject, body, config, isHtml);
        }



        public async Task<(bool success, string errorMsg)> SendEmailAsync(
            string senderName,
            string senderEmail,
            string recepientName,
            string recepientEmail,
            string subject,
            string body,
            SmtpConfig config = null,
            bool isHtml = true)
        {
            var from = new MailboxAddress(senderName, senderEmail);
            var to = new MailboxAddress(recepientName, recepientEmail);

            return await SendEmailAsync(from, new MailboxAddress[] { to }, subject, body, config, isHtml);
        }



        public async Task<(bool success, string errorMsg)> SendEmailAsync(
            MailboxAddress sender,
            MailboxAddress[] recepients,
            string subject,
            string body,
            SmtpConfig config = null,
            bool isHtml = true)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(sender);
            message.To.AddRange(recepients);
            message.Subject = subject;
            message.Body = isHtml ? new BodyBuilder { HtmlBody = body }.ToMessageBody() : new TextPart("plain") { Text = body };

            try
            {
                if (config == null)
                    config = _config;

                using (var client = new SmtpClient())
                {
                    if (!config.UseSSL)
                        client.ServerCertificateValidationCallback = (object sender2, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;

                    await client.ConnectAsync(config.Host, config.Port, config.UseSSL).ConfigureAwait(false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    if (!string.IsNullOrWhiteSpace(config.UsernameToSend))
                        await client.AuthenticateAsync(config.UsernameToSend, config.PasswordToSend).ConfigureAwait(false);

                    await client.SendAsync(message).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }

                return (true, null);
            }
            catch (Exception ex)
            {
                Utilities.CreateLogger<EmailSender>().LogError(LoggingEvents.SEND_EMAIL, ex, "An error occurred whilst sending email");
                return (false, ex.Message);
            }
        }

        public Task SendEmailAsync(Email email)
        {
            var emailSettings = _config;
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (s, Cer, Claim, SslPolicyErrors) => true;
                //Smtp Server 
                string SmtpServer = emailSettings.Host;
                //Smtp Port Number 
                int SmtpPortNumber = emailSettings.Port;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(emailSettings.EmailAddressToSend, emailSettings.EmailAddressToSend));
                foreach (var toAddress in email.To)
                {
                    mimeMessage.To.Add(new MailboxAddress("", toAddress));
                }
                mimeMessage.Subject = email.Subject;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = WebUtility.HtmlDecode(email.Body);
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(SmtpServer, SmtpPortNumber, SecureSocketOptions.Auto);
                    // Note: only needed if the SMTP server requires authentication 
                    // Error 5.5.1 Authentication  
                    client.Authenticate(emailSettings.UsernameToSend, emailSettings.PasswordToSend);
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error y no hemos podido enviar el email.");
            }

            return Task.CompletedTask;
        }

        public async void SendNotifyTomorrowControlsMailAsync(List<Treatment> treatments)
        {
            List<IMaileable> elementosBody = new List<IMaileable>();
            List<IMaileable> elementosSubject = new List<IMaileable>();
            EmailTemplate template = this._emailTemplateService.GetTemplate(TipoEmailTemplate.TomorrowControls);
            foreach(var treatment in treatments)
            {
                EmailBuilder emailBuilder = new EmailBuilder();
                emailBuilder.AddDestino(treatment.Patient.Email);
                emailBuilder.SetTemplate(template);
                emailBuilder.AddElementoSubject(treatment);
                emailBuilder.AddElementoBody(treatment);
                emailBuilder.AddElementoSubject(treatment.Patient);
                emailBuilder.AddElementoBody(treatment.Patient);
                Email email = emailBuilder.Build();
                await SendEmailAsync(email);
            }
        }

        public string GetEmailToReceive()
        {
            return _config.EmailAddressToReceive;
        }
    }



    public class SmtpConfig :IMaileable
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }

        public string Name { get; set; }
        public string UsernameToReceive { get; set; }
        public string EmailAddressToReceive { get; set; }
        public string PasswordToReceive { get; set; }
        public string UsernameToSend { get; set; }
        public string EmailAddressToSend { get; set; }
        public string PasswordToSend { get; set; }

        public List<Tag> getTags()
        {
            List<Tag> tags = new List<Tag>();
            tags.Add(new Tag("{EMAIL_TO_RECEIVE}", EmailAddressToReceive));
            return tags;
        }
    }
}
