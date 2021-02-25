using DnDProject.Backend.Processors.Interfaces.SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.Sendgrid.Formats
{
    public class BasicRegistrationEmail : IRegistrationEmailFormat
    {
        public SendGridMessage CreateRegistrationMessage(string DestinationEmail, string callbackUrl)
        {
            var from = new EmailAddress(Environment.GetEnvironmentVariable("SendGridSenderEmail"));
            var subject = "Confirm account registration!";
            var to = new EmailAddress(DestinationEmail);
            var plainTextContent = "";
            var htmlContent = "Please confirm your account by clicking <a href =\"" + callbackUrl + "\">here</a>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            return msg;
        }
    }
}
