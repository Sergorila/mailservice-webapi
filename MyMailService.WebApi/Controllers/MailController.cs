using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyMailService.BLL.Interfaces;
using MyMailService.DomainViews;
using MyMailService.Entities;

namespace MyMailService.WebApi.Controllers;

public class MailController : Controller
{
    /// <summary>
    /// Логика обрабатывающая письма.
    /// </summary>
    private readonly IMailLogic _mailLogic;
    
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера
    /// </summary>
    /// <param name="mailLogic"></param>
    /// <param name="mapper"></param>
    public MailController(IMailLogic mailLogic, IMapper mapper)
    {
        _mailLogic = mailLogic;
        _mapper = mapper;
    }

    /// <summary>
    /// Get запрос для получения всех записей о письмах из бд.
    /// </summary>
    /// <returns>Список записей в формате json</returns>
    [HttpGet]
    [Route("api/mails")]
    public IActionResult GetMails()
    {
        try
        {
            var mails = _mailLogic.GetMailsAsync();
            if (mails != null)
            {
                return Ok(mails);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest($"{ex.GetType()}: {ex.Message}");
        }
        catch (Exception)
        {
            IActionResult badRequestObjectResult = BadRequest("Bad request.");
            return badRequestObjectResult;
        }
    }

    /// <summary>
    /// Post запрос для отправки писма и создания записи в бд.
    /// </summary>
    /// <returns>Статус 200, если успешно отправил и сохранил запись
    /// 400 если произошла ошибка</returns>
    [HttpPost]
    [Route("api/mails")]
    public async Task<IActionResult> AddMail([FromBody] MailView mail)
    {
        try
        {
            await _mailLogic.AddMailAsync(_mapper.Map<Mail>(mail));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest("Bad request.");
        }
    }
}