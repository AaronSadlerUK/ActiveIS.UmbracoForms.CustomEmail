using System;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Umbraco.Core.Logging;

namespace ActiveIS.UmbracoForms.CustomEmail.Helpers
{
    internal class HandleSmtp
    {
        private readonly ILogger _logger;

        private HandleSmtp(ILogger logger)
        {
            _logger = logger;
        }
        internal void SendEmail(string emailBody, string toEmail, string fromEmail, string fromName, string subject)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = subject,
                Body = emailBody,
                IsBodyHtml = true,
            };

            message.To.Add(toEmail);


            SmtpClient client = new SmtpClient();

            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
            }
        }
    }
}
