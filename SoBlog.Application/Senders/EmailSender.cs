using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SoBlog.Application.Senders
{
    public interface IEmailSender
    {
        void Send(string To, string Subject, string Body);
    }

    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(string To, string Subject, string Body)
        {

            var emailAddress = _configuration.GetValue<string>("SiteSettings:SiteEmail");
            var password = _configuration.GetValue<string>("SiteSettings:EmailPassword");
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(emailAddress, "بلاگ سو");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(emailAddress, password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}


