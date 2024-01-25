using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MyMailService.BLL;
using MyMailService.BLL.Interfaces;
using MyMailService.BLL.SmtpModule;
using MyMailService.DAL;
using MyMailService.DAL.Context;
using MyMailService.DAL.Interfaces;
using MyMailService.WebApi.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterSmtpClient(builder.Configuration);
builder.Services.RegisterSmtpMailAddress(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MyMailService.WebApi.Views.AutoMapper));
builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbContextConfigure = builder.Configuration.GetSection("EnvironmentVariables").Get<EnvironmentVariables>();

builder.Services.AddDbContext<NpgsqlContext>(
    options => options.UseNpgsql(dbContextConfigure?.ConnectionString));

builder.Services.AddScoped<IMailDao, MailDao>();
builder.Services.AddScoped<IMailLogic, MailLogic>();
builder.Services.AddScoped<ISmtpLogic, SmtpLogic>();
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        var jsonConverter = new JsonStringEnumConverter();
        options.JsonSerializerOptions.Converters.Add(jsonConverter);
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();