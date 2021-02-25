using DnDProject.Backend.Processors.Implementations.Sendgrid.Formats;
using DnDProject.Backend.Processors.Interfaces.SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.Sendgrid
{
    public class BasicEmailFactory : IEmailFactory
    {
        public  IRegistrationEmailFormat getRegistrationFormat()
        {
            return new BasicRegistrationEmail();
        }
        
    }
}
