using MyMailService.DAL.Context;

namespace MyMailService.DAL.DAO;

public class BaseDao
{
    /// <summary>
    /// Контекст для взаимодейстия с бд
    /// </summary>
    protected readonly NpgsqlContext DbContext;

    /// <summary>
    /// Получение контекста.
    /// </summary>
    /// <param name="dbContext"></param>
    protected BaseDao(NpgsqlContext dbContext)
    {
        DbContext = dbContext;
    }
}