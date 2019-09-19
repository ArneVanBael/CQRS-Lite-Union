using AutoMapper;
using CQRS_Lite_Union_API.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Lite_Union_API.WebApi.Common
{
    [Produces("application/json")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; private set; }
        public IMapper Mapper { get; private set; }

        public BaseController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }

        protected IActionResult BuildHttpResponse(IResponse businessResponse)
        {
            if (businessResponse.IsSuccessFull())
                return Ok();
            else
                return ErrorResponse(businessResponse.Error.Type, businessResponse.Error.Message);
        }

        protected IActionResult BuildHttpResponse<TBusinessResult, TJsonResult>(IResponse<TBusinessResult> businessResponse)
        {
            return businessResponse.IsSuccessFull()
                ? Ok(Mapper.Map<TBusinessResult, TJsonResult>(businessResponse.Value))
                : ErrorResponse(businessResponse.Error.Type, businessResponse.Error.Message);
        }

        private ObjectResult ErrorResponse(ErrorMessageType type, string message)
        {
            return StatusCode((int)type, new { errorMessage = message }); 
        }
    }
}
