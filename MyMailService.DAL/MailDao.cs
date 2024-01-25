using MyMailService.DAL.Context;
using MyMailService.DAL.DAO;
using MyMailService.DAL.Interfaces;
using MyMailService.Entities;

namespace MyMailService.DAL;

public class MailDao : BaseDao, IMailDao
{
    /// <summary>
    /// Контекст, для доступа к данным.
    /// </summary>
    /// <param name="dbContext"></param>
    public MailDao(NpgsqlContext dbContext) : base(dbContext) { }
    
    /// <summary>
    /// Добавление запись о письме в бд 
    /// </summary>
    /// <param name="mail"></param>
    public async Task AddMailAsync(Mail mail)
    {
        await DbContext.Mails.AddAsync(mail);
        await DbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получение всех записей о письмах из бд в формате json
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Mail> GetMailsAsync()
    {
        return DbContext.Mails.ToList();
    }
}