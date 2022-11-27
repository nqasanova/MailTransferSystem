using System;
namespace MailTransferSystem.Database.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string From { get; set; }

        public int EmailId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public Email TargetEmail { get; set; }

        public int TargetEmailId { get; set; }
    }
}