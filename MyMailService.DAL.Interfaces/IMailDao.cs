using MyMailService.Entities;

namespace MyMailService.DAL.Interfaces;

public interface IMailDao
{
    /// <summary>
    /// Ассинхронно добавить запись о письме в базу 
    /// </summary>
    /// <param name="mail"></param>
    /// <returns></returns>
    Task AddMailAsync(Mail mail);
    
    /// <summary>
    /// Асинхронно получить все записи о письмах из бд
    /// </summary>
    /// <returns></returns>
    IEnumerable<Mail> GetMailsAsync();
}