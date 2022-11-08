using System;
using SimpleEmailApp.Model;

namespace SimpleEmailApp.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}

