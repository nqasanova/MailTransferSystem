using System;
using MailTransferSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MailTransferSystem.Database
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EmailService;Trusted_Connection=false;User=SA;Password=Nata2004.;TrustServerCertificate=True;");
        }

        public DbSet<Email> Emails { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}