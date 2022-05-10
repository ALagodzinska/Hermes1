using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HermesChat.Services
{
    public class EmailService
    {
        public Task SendAsync(IdentityMessage message)
        {
            SmtpClient client = new SmtpClient();
            return client.SendMailAsync(ConfigurationManager.AppSettings["SupportEmailAddr"],
                                        message.Destination,
                                        message.Subject,
                                        message.Body);
        }
    }

}
