using CQRS_Lite_Union_API.Application.Workshops.Commands;
using System.Threading;
using System.Threading.Tasks;
using CQRS_Lite_Union_API.Application.Utils;
using CQRS_Lite_Union_API.Common.Response;
using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Domain.Workshops;
using CQRS_Lite_Union_API.Application.Workshops.Result;

namespace CQRS_Lite_Union_API.Application.Workshops.CommandHandlers
{
    public class CreateWorkshopCommandHandler : CommandHandlerBase<CreateWorkshopCommand, IResponse<CreateWorkshopResult>>
    {
        public CreateWorkshopCommandHandler(IAppContext context) : base(context)
        {
        }

        protected override async Task<IResponse<CreateWorkshopResult>> HandleAsync(CreateWorkshopCommand command, CancellationToken cancellationToken)
        {
            var workshop = CreateWorkshopFromCommand(command);

            await Context.WorkshopsCommandRepository.AddAsync(workshop);
            await Context.SaveChangesAsync();

            return Response.Ok(new CreateWorkshopResult(workshop.Id));
        }

        private Workshop CreateWorkshopFromCommand(CreateWorkshopCommand command)
        {
            return new Workshop
            {
                Description = command.Description,
                Name = command.Name,
                StartDate = command.StartDate,
                EndDate = command.EndDate
            };
        }
    }
}
