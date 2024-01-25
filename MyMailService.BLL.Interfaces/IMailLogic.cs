using MyMailService.Entities;

namespace MyMailService.BLL.Interfaces;

public interface IMailLogic
{
    /// <summary>
    /// Ассинхронно добавить запись о письме в базу
    /// </summary>
    /// <param name="Объект mail"></param>
    /// <returns></returns>
    Task AddMailAsync(Mail mail);
    
    /// <summary>
    /// Асинхронно получить все записи о письмах из бд
    /// </summary>
    /// <returns></returns>
    IEnumerable<Mail> GetMailsAsync();
}