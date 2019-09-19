using AutoMapper;
using CQRS_Lite_Union_API.Application.Workshops.Result;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Models.GetWorkshops
{
    public class GetWorkshopsMapping : Profile
    {
        public GetWorkshopsMapping()
        {
            CreateMap<GetWorkshopsResult, GetWorkshopsResponse>();
        }
    }
}
