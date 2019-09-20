using CQRS_Lite_Union_API.Common.Response;
using MediatR;
namespace CQRS_Lite_Union_API.Application.Attendees.Commands
{
    public class UnRegisterAttendeeCommand : IRequest<IResponse>
    {
        public UnRegisterAttendeeCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
