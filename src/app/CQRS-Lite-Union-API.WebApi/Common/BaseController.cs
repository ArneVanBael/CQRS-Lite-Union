using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.WebApi.Common
{
    [Produces("application/json")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; set; }

        public BaseController(IMediator mediator )
        {
            Mediator = mediator;
        }
    }
}
