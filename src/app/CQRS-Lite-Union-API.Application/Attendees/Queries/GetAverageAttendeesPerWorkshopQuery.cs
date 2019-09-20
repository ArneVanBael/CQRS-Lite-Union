using CQRS_Lite_Union_API.Application.Attendees.Result;
using CQRS_Lite_Union_API.Common.Response;
using MediatR;

namespace CQRS_Lite_Union_API.Application.Attendees.Queries
{
    public class GetAverageAttendeesPerWorkshopQuery : IRequest<IResponse<AverageAttendeesPerWorkshopResult>>
    {
    }
}
