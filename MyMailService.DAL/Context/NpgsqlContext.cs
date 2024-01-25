using Microsoft.EntityFrameworkCore;
using MyMailService.Entities;

namespace MyMailService.DAL.Context;

public class NpgsqlContext : DbContext
{
    /// <summary>
    /// Набор объектов mail
    /// </summary>
    public DbSet<Mail> Mails { get; set; }
    
    /// <summary>
    /// Конструктор контекста для взаимодействия с PostgreSQL
    /// </summary>
    /// <param name="options"></param>
    public NpgsqlContext(DbContextOptions<NpgsqlContext> options) : base(options) {}
    
}