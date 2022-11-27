using MailTransferSystem.Controllers;
using MailTransferSystem.Database;
using MailTransferSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace MailTransferSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var emailconfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
        builder.Services.AddControllers();

        builder.Services.AddMvc();

        var app = builder.Build();

        builder.Services

            .AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer("Server=localhost;Database=EmailService;Trusted_Connection=false;User=SA;Password=Nata2004.;TrustServerCertificate=True;");
            }, ServiceLifetime.Scoped)
             .AddScoped<IEmailSender, EmailSender>()

             .AddMvc();

        app.UseStaticFiles();

        app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}");

        app.Run();
    }
}