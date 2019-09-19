using AutoMapper;
using CQRS_Lite_Union_API.Application.Workshops.Result;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Models.GetAttendeesOfWorkshop
{
    public class GetAttendeesOfWorkshopMapping : Profile
    {
        public GetAttendeesOfWorkshopMapping()
        {
            CreateMap<GetAttendeesOfWorkshopResult, GetAttendeesOfWorkshopResponse>();
            CreateMap<WorkshopAttendeeDTO, WorkshopAttendeeResponse>();
        }
    }
}
