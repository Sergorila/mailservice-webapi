using System.Net;
using System.Net.Mail;
using MyMailService.BLL.SmtpModule;

namespace MyMailService.WebApi.Utils;

public static class SmtpMailAddressRegistration
{
    /// <summary>
    /// Регистрация отправителя в DI
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void RegisterSmtpMailAddress(this IServiceCollection services, ConfigurationManager configuration)
    {
        var mailAddressConfigure = configuration.GetSection("Smtp").Get<SmtpConfigure>();
        
        var smtpMailAddress = new MailAddress(mailAddressConfigure?.Username);
        
        services.AddSingleton(smtpMailAddress);
    }
}