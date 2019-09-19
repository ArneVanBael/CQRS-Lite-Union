using AutoMapper;
using CQRS_Lite_Union_API.Application.Workshops.Commands;
using CQRS_Lite_Union_API.Application.Workshops.Result;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Models.CreateWorkshop
{
    public class CreateworkshopMapping : Profile
    {
        public CreateworkshopMapping()
        {
            CreateMap<CreateWorkshopRequest, CreateWorkshopCommand>();
            CreateMap<CreateWorkshopResult, CreateWorkshopResponse>();
        }
    }
}
