using CQRS_Lite_Union_API.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Utils
{
    public abstract class CommandHandlerBase<TRequest> : IRequestHandler<TRequest, IResponse> where TRequest : IRequest<IResponse>
    {
        public async Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            IResponse response;

            try
            {
                // start transaction

                response = await HandleAsync(request, cancellationToken);

                // commit transaction
            }
            catch (Exception ex)
            {
                // log exception
                // rollback transaction
                throw;
            }

            return response;
        }

        protected abstract Task<IResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}
