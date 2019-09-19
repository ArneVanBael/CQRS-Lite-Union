using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Application.Attendees.Commands;
using CQRS_Lite_Union_API.Application.Attendees.Result;
using CQRS_Lite_Union_API.Application.Utils;
using CQRS_Lite_Union_API.Common.Response;
using CQRS_Lite_Union_API.Domain.Attendees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Attendees.CommandHandlers
{
    public class RegisterAttendeeCommandHandler : CommandHandlerBase<RegisterAttendeeCommand, IResponse<RegisterAttendeeResult>>
    {
        public RegisterAttendeeCommandHandler(IAppContext context) : base(context)
        {
        }

        protected async override Task<IResponse<RegisterAttendeeResult>> HandleAsync(RegisterAttendeeCommand command, CancellationToken cancellationToken)
        {
            var workshop = await Context.WorkshopsQueryRepository.Include(x => x.Attendees).SingleOrDefaultAsync(x => x.Id == command.WorkshopId);
            if (workshop == null) return Response.Fail<RegisterAttendeeResult>($"Workshop with id: '{command.WorkshopId}' does not exist", ErrorMessageType.NotFound);

            var attendee = CreateAttendeeFromCommand(command);

            var registerResponse = workshop.RegisterAttendee(attendee);
            if (!registerResponse.IsSuccessFull()) return Response.Fail<RegisterAttendeeResult>(registerResponse.Error.Message, registerResponse.Error.Type);

            Context.WorkshopsCommandRepository.Update(workshop);
            await Context.SaveChangesAsync();

            return Response.Ok(new RegisterAttendeeResult(attendee.Id));
        }

        private Attendee CreateAttendeeFromCommand(RegisterAttendeeCommand command)
        {
            return new Attendee
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Company = command.Company
            };
        }
    }
}
