using CQRS_Lite_Union_API.Application.Workshops.Result;
using CQRS_Lite_Union_API.Common.Response;
using MediatR;

namespace CQRS_Lite_Union_API.Application.Workshops.Queries
{
    public class GetAttendeesOfWorkshopQuery : IRequest<IResponse<GetAttendeesOfWorkshopResult>>
    {
        public GetAttendeesOfWorkshopQuery(int id)
        {
            WorkshopId = id;
        }
        public int WorkshopId { get; set; }
    }
}
