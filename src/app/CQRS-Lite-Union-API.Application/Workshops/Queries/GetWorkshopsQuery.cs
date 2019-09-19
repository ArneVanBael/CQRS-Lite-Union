using CQRS_Lite_Union_API.Application.Workshops.Result;
using CQRS_Lite_Union_API.Common.Response;
using MediatR;
using System.Collections.Generic;

namespace CQRS_Lite_Union_API.Application.Workshops.Queries
{
    public class GetWorkshopsQuery : IRequest<IResponse<List<GetWorkshopsResult>>>
    {
    }
}
