using System;
using System.Configuration;
using System.Net.Mail;

namespace TestableApplication
{
    public class EmailSender
    {
        public void Send(string email, string content, string subject)
        {
            using (var client = new SmtpClient())
            {
                var smtpEmail = ConfigurationManager.AppSettings["SmtpUser"];
                var smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
                var smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
                var smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = smtpHost;
                client.Port = smtpPort;
                client.Credentials = new System.Net.NetworkCredential(smtpEmail, smtpPassword);

                using (var mail = new MailMessage(smtpEmail, email))
                {
                    mail.Subject = subject;
                    mail.Body = content;

                    client.Send(mail);
                }
            }
        }
    }
}