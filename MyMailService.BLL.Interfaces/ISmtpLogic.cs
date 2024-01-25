using MyMailService.Entities;

namespace MyMailService.BLL.Interfaces;

public interface ISmtpLogic
{
    /// <summary>
    /// Асинхронно сформировать и отправить письмо адресатам.
    /// Вернет статус отправки и текст ошкибки.
    /// </summary>
    /// <param name="mail"></param>
    /// <returns></returns>
    Task<(bool, string)> SendEmailAsync(Mail mail);
}