using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Application.Utils;
using CQRS_Lite_Union_API.Application.Workshops.Queries;
using CQRS_Lite_Union_API.Application.Workshops.Result;
using CQRS_Lite_Union_API.Common.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Workshops.QueryHandlers
{
    public class GetAttendeesOfWorkshopQueryHandler : QueryHandlerBase<GetAttendeesOfWorkshopQuery, GetAttendeesOfWorkshopResult>
    {
        public GetAttendeesOfWorkshopQueryHandler(IAppContext context) : base(context)
        {
        }

        protected async override Task<IResponse<GetAttendeesOfWorkshopResult>> HandleAsync(GetAttendeesOfWorkshopQuery query, CancellationToken cancellationToken)
        {
            var workshopWithAttendees = await Context.WorkshopsQueryRepository
                .Include(x => x.Attendees)
                .Select(GetAttendeesOfWorkshopResult.Projection)
                .SingleOrDefaultAsync(x => x.WorkshopId == query.WorkshopId);

            return Response.Ok(workshopWithAttendees);
        }
    }
}
