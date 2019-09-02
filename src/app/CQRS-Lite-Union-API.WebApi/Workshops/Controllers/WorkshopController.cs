using CQRS_Lite_Union_API.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Controllers
{
    [Route("/api/workshops")]
    public class WorkshopController : BaseController
    {
        public WorkshopController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost("")]
        public async Task<IActionResult> CreateWorkshop() // command
        {
            return Ok("dit is een test");
        }

        [HttpGet("")]
        public async Task<IActionResult> GetWorkshops() // query
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindWorkshop(int id) // query
        {
            return Ok(id);
        }
    }
}
