namespace MyMailService.DomainViews;

public class MailView
{
    /// <summary>
    /// Поле "Тема" письма для json запроса
    /// </summary>
    public string Subject { get; set; }
    
    /// <summary>
    /// Поле "Текст" письма для json запроса
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Поле "Получатели" письма для json запроса
    /// </summary>
    public List<string> Recipients { get; set; }
}