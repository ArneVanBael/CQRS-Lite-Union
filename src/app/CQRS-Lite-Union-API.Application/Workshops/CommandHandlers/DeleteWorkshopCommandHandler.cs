using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Application.Utils;
using CQRS_Lite_Union_API.Application.Workshops.Commands;
using CQRS_Lite_Union_API.Common.Response;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Workshops.CommandHandlers
{
    public class DeleteWorkshopCommandHandler : CommandHandlerBase<DeleteWorkshopCommand, IResponse>
    {
        public DeleteWorkshopCommandHandler(IAppContext context) : base(context)
        {
        }

        protected async override Task<IResponse> HandleAsync(DeleteWorkshopCommand command, CancellationToken cancellationToken)
        {
            if (command.Id <= default(int)) return Response.Fail("workshop id must be greater than 0", ErrorMessageType.BadRequest);

            var workshop = Context.WorkshopsCommandRepository.SingleOrDefault(x => x.Id == command.Id);
            if (workshop == null) return Response.Fail($"Workshop with id '{command.Id}' is not found", ErrorMessageType.NotFound);

            Context.WorkshopsCommandRepository.Remove(workshop);
            await Context.SaveChangesAsync();

            return Response.Ok();
        }
    }
}
