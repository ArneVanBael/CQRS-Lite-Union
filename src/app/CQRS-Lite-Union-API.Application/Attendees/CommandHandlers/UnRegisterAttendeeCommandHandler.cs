using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Application.Attendees.Commands;
using CQRS_Lite_Union_API.Application.Utils;
using CQRS_Lite_Union_API.Common.Response;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Lite_Union_API.Application.Attendees.CommandHandlers
{
    public class UnRegisterAttendeeCommandHandler : CommandHandlerBase<UnRegisterAttendeeCommand, IResponse>
    {
        public UnRegisterAttendeeCommandHandler(IAppContext context) : base(context)
        {
        }

        protected async override Task<IResponse> HandleAsync(UnRegisterAttendeeCommand command, CancellationToken cancellationToken)
        {
            var attendee = await Context.AttendeeCommandRepository.SingleOrDefaultAsync(x => x.Id == command.Id);
            if (attendee == null) return Response.Fail($"No attendee found with id: '{command.Id}'", ErrorMessageType.NotFound);

            Context.AttendeeCommandRepository.Remove(attendee);
            await Context.SaveChangesAsync();

            return Response.Ok();
        }
    }
}
