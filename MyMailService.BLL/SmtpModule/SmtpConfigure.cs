namespace MyMailService.BLL.SmtpModule;

public class SmtpConfigure
{
    /// <summary>
    /// Адрес сервера для отправки сообщений
    /// </summary>
    public string Host { get; set; }
    
    /// <summary>
    /// Адрес отправителя
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Пароль для внешних приложений
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Порт для сервера
    /// </summary>
    public int Port { get; set; }
}