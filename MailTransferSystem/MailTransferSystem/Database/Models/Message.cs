using System;
using MimeKit;

namespace MailTransferSystem.Database.Models
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(List<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(m => new MailboxAddress(string.Empty, m)));

            Subject = subject;
            Content = content;
        }
    }
}