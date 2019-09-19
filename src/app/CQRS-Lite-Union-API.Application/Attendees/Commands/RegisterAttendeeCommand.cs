using CQRS_Lite_Union_API.Application.Attendees.Result;
using CQRS_Lite_Union_API.Common.Response;
using MediatR;

namespace CQRS_Lite_Union_API.Application.Attendees.Commands
{
    public class RegisterAttendeeCommand : IRequest<IResponse<RegisterAttendeeResult>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int WorkshopId { get; set; }
        public string Company { get; set; }
    }
}
