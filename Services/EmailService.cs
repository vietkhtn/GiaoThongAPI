using HumanResource.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Infrastructure.Services
{
    public class EmailService
    {
        // This class is used by the application to send email for account confirmation and password reset.
        // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
        public class EmailSender : IEmailService
        {
            public Task SendEmailAsync(string email, string subject, string message)
            {
                // TODO: Wire this up to actual email sending logic via SendGrid, local SMTP, etc.
                return Task.CompletedTask;
            }
        }
    }
}
