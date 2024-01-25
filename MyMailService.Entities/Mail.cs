using System.Collections.Generic;

namespace MyMailService.Entities;

public class Mail : BaseEntity
{
    /// <summary>
    /// Id записи в бд.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Тема письма
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Текст письма
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Список получателей письма
    /// </summary>
    public List<string> Recipients { get; set; }

    /// <summary>
    /// Результат отправки сообщения (Ok или Failed)
    /// </summary>
    public string ResultMessage { get; set; }

    /// <summary>
    /// Текст ошибки при отправки письма (не пустой, если статус отправки Failed)
    /// </summary>
    public string FailedMessage { get; set; }
}