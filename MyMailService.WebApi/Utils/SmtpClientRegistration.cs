using System.Net;
using System.Net.Mail;
using MyMailService.BLL.SmtpModule;

namespace MyMailService.WebApi.Utils;

public static class SmtpClientRegistration
{
    /// <summary>
    /// Регистрация smtp клиента в DI
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void RegisterSmtpClient(this IServiceCollection services, ConfigurationManager configuration)
    {
        var smtpConfigure = configuration.GetSection("Smtp").Get<SmtpConfigure>();
        var smtpClient = new SmtpClient()
        {
            Host = smtpConfigure.Host, 
            Port = smtpConfigure.Port, 
            Credentials = new NetworkCredential(smtpConfigure.Username, smtpConfigure.Password),
            EnableSsl = true
        };
        
        services.AddSingleton(smtpClient);
    }
}