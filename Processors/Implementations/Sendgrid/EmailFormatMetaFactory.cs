using DnDProject.Backend.Processors.Interfaces.SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.Sendgrid
{
    public static class EmailFormatMetaFactory
    {
        public static IEmailFactory getBasicEmailFactory()
        {
            return new BasicEmailFactory();
        }
    }
}
