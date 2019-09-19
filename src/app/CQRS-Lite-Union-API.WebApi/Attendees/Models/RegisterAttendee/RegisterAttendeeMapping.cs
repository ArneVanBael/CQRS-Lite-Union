using AutoMapper;
using CQRS_Lite_Union_API.Application.Attendees.Commands;
using CQRS_Lite_Union_API.Application.Attendees.Result;

namespace CQRS_Lite_Union_API.WebApi.Attendees.Models.RegisterAttendee
{
    public class RegisterAttendeeMapping : Profile
    {
        public RegisterAttendeeMapping()
        {
            CreateMap<RegisterAttendeeRequest, RegisterAttendeeCommand>();
            CreateMap<RegisterAttendeeResult, RegisterAttendeeResponse>();
        }
    }
}
