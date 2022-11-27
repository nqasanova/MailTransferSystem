using System;
using System.ComponentModel.DataAnnotations;
using MailTransferSystem.Database.Models;

namespace MailTransferSystem.ViewModels
{
    public class AddViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string From { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public Email TargetEmail { get; set; }

        public string Message { get; set; }

        public bool IsBulk { get; set; }
    }
}