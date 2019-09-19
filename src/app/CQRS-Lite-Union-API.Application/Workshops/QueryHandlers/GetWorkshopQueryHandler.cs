using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Application.Workshops.Queries;
using CQRS_Lite_Union_API.Application.Workshops.Result;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using CQRS_Lite_Union_API.Application.Utils;
using CQRS_Lite_Union_API.Common.Response;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Lite_Union_API.Application.Workshops.QueryHandlers
{
    public class GetWorkshopQueryHandler : QueryHandlerBase<GetWorkshopQuery, GetWorkshopResult>
    {
        public GetWorkshopQueryHandler(IAppContext context) : base(context)
        {
        }
      
        protected async override Task<IResponse<GetWorkshopResult>> HandleAsync(GetWorkshopQuery query, CancellationToken cancellationToken)
        {
            var workshop = await Context.WorkshopsQueryRepository
                .Include(x => x.Attendees)
                .Select(GetWorkshopResult.Projection)
                .SingleOrDefaultAsync();

            if (workshop == null)
                return Response.Fail<GetWorkshopResult>($"The workshop with id '{query.Id}' could not be found", ErrorMessageType.NotFound);

            return Response.Ok(workshop);
        }
    }
}
