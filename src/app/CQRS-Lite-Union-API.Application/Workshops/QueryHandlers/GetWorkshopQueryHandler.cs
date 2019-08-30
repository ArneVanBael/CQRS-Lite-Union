using CQRS_Lite_Union_API.Application.Workshops.Queries;
using CQRS_Lite_Union_API.Application.Workshops.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Workshops.QueryHandlers
{
    public class GetWorkshopQueryHandler : IRequestHandler<GetWorkshopQuery, GetWorkshopResult>
    {
        // need queryBasehandler for wrapping into response envelope

        public GetWorkshopQueryHandler()
        {
        }

        public async Task<GetWorkshopResult> Handle(GetWorkshopQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
