using AutoMapper;
using CQRS_Lite_Union_API.Application.Workshops.Commands;
using CQRS_Lite_Union_API.Application.Workshops.Queries;
using CQRS_Lite_Union_API.Application.Workshops.Result;
using CQRS_Lite_Union_API.WebApi.Common;
using CQRS_Lite_Union_API.WebApi.Workshops.Models.CreateWorkshop;
using CQRS_Lite_Union_API.WebApi.Workshops.Models.FindWorkshop;
using CQRS_Lite_Union_API.WebApi.Workshops.Models.GetAttendeesOfWorkshop;
using CQRS_Lite_Union_API.WebApi.Workshops.Models.GetWorkshops;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Controllers
{
    [Route("/api/workshops")]
    [ApiController]
    public class WorkshopController : BaseController
    {
        public WorkshopController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateWorkshop(CreateWorkshopRequest createWorkshopRequest) // command
        {
            var command = Mapper.Map<CreateWorkshopCommand>(createWorkshopRequest);
            var response = await Mediator.Send(command);

            return BuildHttpResponse<CreateWorkshopResult, CreateWorkshopResponse>(response);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetWorkshops() // query
        {
            var query = new GetWorkshopsQuery();
            var response = await Mediator.Send(query);

            return BuildHttpResponse<List<GetWorkshopsResult>, List<GetWorkshopsResponse>>(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindWorkshop(int id) // query
        {
            var query = new GetWorkshopQuery(id);
            var response = await Mediator.Send(query);

            return BuildHttpResponse<GetWorkshopResult,FindWorkshopResponse > (response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkshop(int id) // command
        {
            var command = new DeleteWorkshopCommand(id);
            var response = await Mediator.Send(command);

            return BuildHttpResponse(response);
        }

        [HttpGet("{id}/attendees")]
        public async Task<IActionResult> GetAttendeesOfWorkshop(int id) // query
        {
            var query = new GetAttendeesOfWorkshopQuery(id);
            var response = await Mediator.Send(query);

            return BuildHttpResponse<GetAttendeesOfWorkshopResult, GetAttendeesOfWorkshopResponse>(response);
        }
    }
}
