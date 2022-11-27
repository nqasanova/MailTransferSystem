using System;
namespace MailTransferSystem.Controllers
{
    public class EmailConfiguration
    {
        public int Port { get; set; }
        public string From { get; set; }
        public string SMTPServer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}