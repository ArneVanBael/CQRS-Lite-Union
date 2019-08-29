using CQRS_Lite_Union_API.Application.Workshops.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CQRS_Lite_Union_API.Application.Utils;
using CQRS_Lite_Union_API.Common.Response;

namespace CQRS_Lite_Union_API.Application.Workshops.CommandHandlers
{
    public class CreateWorkshopCommandHandler : CommandHandlerBase<CreateWorkshopCommand>
    {
        protected override async Task<IResponse> HandleAsync(CreateWorkshopCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
