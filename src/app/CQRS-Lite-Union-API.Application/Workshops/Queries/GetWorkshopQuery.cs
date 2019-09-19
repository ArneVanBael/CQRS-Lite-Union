using CQRS_Lite_Union_API.Application.Workshops.Result;
using CQRS_Lite_Union_API.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Application.Workshops.Queries
{
    public class GetWorkshopQuery : IRequest<IResponse<GetWorkshopResult>>
    {
        public GetWorkshopQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
