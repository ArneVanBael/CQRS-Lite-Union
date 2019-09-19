using AutoMapper;
using CQRS_Lite_Union_API.Application.Workshops.Result;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Models.FindWorkshop
{
    public class FindWorkshopMapping : Profile
    {
        public FindWorkshopMapping()
        {
            CreateMap<GetWorkshopResult, FindWorkshopResponse>();
        }
    }
}
