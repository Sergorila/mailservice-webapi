using Microsoft.Extensions.Logging;
using MyMailService.BLL.Interfaces;
using MyMailService.DAL.Interfaces;
using MyMailService.Entities;

namespace MyMailService.BLL;

public class MailLogic : BaseLogic, IMailLogic
{
    /// <summary>
    /// Связь логики для отправки письма через интерфейс. 
    /// </summary>
    private readonly ISmtpLogic _smtpLogic;
    
    /// <summary>
    /// Связь логики добавления письма через интерфейс.
    /// </summary>
    private readonly IMailDao _dao;
    
    /// <summary>
    /// Конструктор логики отправки писем через smtp
    /// и информацию об отправке через dbcontext.
    /// </summary>
    /// <param name="Логгер"></param>
    /// <param name="Интерфейс описывающий dbcontext для письма"></param>
    /// <param name="Интерфейс описывающий логику отправки письма"></param>
    public MailLogic(ILogger<BaseLogic> logger, IMailDao dao, ISmtpLogic smtpLogic) : base(logger)
    {
        _dao = dao;
        _smtpLogic = smtpLogic;
    }
    
    /// <summary>
    /// Метод, обрабатывающий отправку письма адресатам.
    /// После отправки записывает статус и текст ошибки(если есть) в объект письма.
    /// Объект письма отправляет в бд.
    /// </summary>
    /// <param name="Объект mail"></param>
    public async Task AddMailAsync(Mail mail)
    {
        try
        {
            Logger.LogInformation("Trying add mail: {Id}", mail.Id);
            Task<(bool, string)> statusMail = _smtpLogic.SendEmailAsync(mail);
            mail.CreatedDate = DateTime.Now;
            mail.ResultMessage = statusMail.Result.Item1 ? "Ok" : "Failed";
            mail.FailedMessage = statusMail.Result.Item2;
            await _dao.AddMailAsync(mail);
            Logger.LogInformation("Complete adding mail: {Id}", mail.Id);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error while adding mail: {Id}", mail.Id);
            throw;
        }
    }
    
    /// <summary>
    /// Метод, предоставляющий все записи из бд о письмах в формате json.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Mail> GetMailsAsync()
    {
        try
        {
            Logger.LogInformation("Trying get list of mails");

            var res = _dao.GetMailsAsync();
            
            Logger.LogInformation("Compete getting list of mails");
            return res;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, 
                "Error while getting list of mails");
            throw;
        }
    }
}