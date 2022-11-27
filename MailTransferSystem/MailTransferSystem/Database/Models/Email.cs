using System;
namespace MailTransferSystem.Database.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string TargetEmail { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}