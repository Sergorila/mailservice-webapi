using System.Net.Mail;
using MyMailService.BLL.Interfaces;
using MyMailService.Entities;

namespace MyMailService.BLL.SmtpModule;

public class SmtpLogic : ISmtpLogic
{
    /// <summary>
    /// Информация об отправителе (email)
    /// </summary>
    private readonly MailAddress _mailAddress;
    
    /// <summary>
    /// Экземпляр smtp клиента
    /// </summary>
    private readonly SmtpClient _smtpClient;
    
    /// <summary>
    /// Констурктор класса, для отправки сообщений
    /// </summary>
    /// <param name="Клиент smtp"></param>
    /// <param name="email отправителя"></param>
    public SmtpLogic(SmtpClient smtpClient, MailAddress mailAddress)
    {
        _smtpClient = smtpClient;
        _mailAddress = mailAddress;
    }
    
    /// <summary>
    /// Метод, для отправки сообщений.
    /// Собирает объект письма и отдает его smtp.
    /// </summary>
    /// <param name="mail"></param>
    /// <returns></returns>
    public async Task<(bool, string)> SendEmailAsync(Mail mail)
    {
        try
        {
            MailMessage mailMessage = new MailMessage()
            {
                From = _mailAddress,
                Subject = mail.Subject,
                Body = mail.Body
            };
            mailMessage.To.Add(String.Join(",", mail.Recipients));
            
            await _smtpClient.SendMailAsync(mailMessage);
            return (true, string.Empty);
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
        
    }
}