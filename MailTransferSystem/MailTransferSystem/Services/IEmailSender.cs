using System;
using MailTransferSystem.Database.Models;

namespace MailTransferSystem.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}