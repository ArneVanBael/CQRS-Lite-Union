using AutoMapper;
using CQRS_Lite_Union_API.Application.Attendees.Result;
namespace CQRS_Lite_Union_API.WebApi.Attendees.Models.GetAverageAttendeesPerWorkshop
{
    public class GetAverageAttendeesPerWorkshopMapping : Profile
    {
        public GetAverageAttendeesPerWorkshopMapping()
        {
            CreateMap<AverageAttendeesPerWorkshopResult, AverageAttendeesPerWorkshopResponse>();
        }
    }
}
