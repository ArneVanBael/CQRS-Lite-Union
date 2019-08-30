using CQRS_Lite_Union_API.Application.Workshops.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Application.Workshops.Queries
{
    public class GetWorkshopQuery : IRequest<GetWorkshopResult>
    {
        public int Id { get; set; }
    }
}
