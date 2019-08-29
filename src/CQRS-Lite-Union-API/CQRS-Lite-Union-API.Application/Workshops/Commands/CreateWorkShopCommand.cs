using CQRS_Lite_Union_API.Common.Response;
using MediatR;
using System;

namespace CQRS_Lite_Union_API.Application.Workshops.Commands
{
    public class CreateWorkshopCommand : IRequest<IResponse>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
