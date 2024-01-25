using AutoMapper;
using MyMailService.DomainViews;
using MyMailService.Entities;

namespace MyMailService.WebApi.Views;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<MailView, Mail>();
    }
}