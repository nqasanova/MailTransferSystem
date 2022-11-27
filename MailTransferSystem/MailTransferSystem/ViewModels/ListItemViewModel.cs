using System;
namespace MailTransferSystem.ViewModels
{
    public class ListItemViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public ListItemViewModel(string from, string to, string title, string message)
        {
            From = from;
            To = to;
            Title = title;
            Message = message;
        }
    }
}