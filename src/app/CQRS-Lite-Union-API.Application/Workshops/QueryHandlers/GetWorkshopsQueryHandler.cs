using System.Collections.Generic;
using CQRS_Lite_Union_API.Application.Utils;
using CQRS_Lite_Union_API.Application.Workshops.Queries;
using CQRS_Lite_Union_API.Application.Workshops.Result;
using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Common.Response;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Lite_Union_API.Application.Workshops.QueryHandlers
{
    public class GetWorkshopsQueryHandler : QueryHandlerBase<GetWorkshopsQuery, List<GetWorkshopsResult>>
    {
        public GetWorkshopsQueryHandler(IAppContext context) : base(context)
        {
        }

        protected override async Task<IResponse<List<GetWorkshopsResult>>> HandleAsync(GetWorkshopsQuery query, CancellationToken cancellationToken)
        {
            var workshops = await Context.WorkshopsQueryRepository
                .Select(GetWorkshopsResult.Projection)
                .ToListAsync();

            return Response.Ok(workshops);
        }
    }
}
