using System;
using MailTransferSystem.Database;
using MailTransferSystem.Database.Models;
using MailTransferSystem.Services;
using MailTransferSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MailTransferSystem.Controllers
{
    public class EmailController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IEmailSender _emailSender;
        private readonly EmailConfiguration _emailConfiguration;

        public EmailController(DataContext dataContext, IEmailSender emailSender, EmailConfiguration emailConfiguration)
        {
            _dataContext = dataContext;
            _emailSender = emailSender;
            _emailConfiguration = emailConfiguration;
        }

        public IActionResult List()
        {
            var model = _dataContext.Notifications
                .Select(n => new ListItemViewModel(n.From, $"{n.TargetEmail.TargetEmail}", n.Title, n.Message))
                .ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] AddViewModel model)
        {
            var not = new Database.Models.Notification
            {
                From = _emailConfiguration.From,
                TargetEmail = model.TargetEmail,
                Title = model.Title,
                Message = model.Message,
            };

            List<string> emails = new List<string>();

            if (model.IsBulk == false)
            {
                var newemails = not.TargetEmail.TargetEmail.Split(',');

                foreach (var e in newemails)
                {
                    emails.Add(e);
                }
            }

            else
            {
                emails.Add(model.TargetEmail.TargetEmail);
            }

            var message = new Message(emails, not.Title, not.Message);

            _dataContext.Notifications.Add(not);
            _emailSender.SendEmail(message);
            _dataContext.Emails.Add(not.TargetEmail);
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(List));
        }
    }
}