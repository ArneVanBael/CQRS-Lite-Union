using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Application.Workshops.Queries;
using CQRS_Lite_Union_API.Application.Workshops.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace CQRS_Lite_Union_API.Application.Workshops.QueryHandlers
{
    public class GetWorkshopQueryHandler : IRequestHandler<GetWorkshopQuery, GetWorkshopResult>
    {
        // need queryBasehandler for wrapping into response envelope
        private readonly IAppContext _context;

        public GetWorkshopQueryHandler(IAppContext context)
        {
            _context = context;
        }

        public async Task<GetWorkshopResult> Handle(GetWorkshopQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
