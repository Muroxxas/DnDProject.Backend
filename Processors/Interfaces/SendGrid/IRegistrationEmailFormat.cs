using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Interfaces.SendGrid
{
    public interface IRegistrationEmailFormat
    {
        SendGridMessage CreateRegistrationMessage(string DestinationEmail, string callbackUrl);
    }
}
