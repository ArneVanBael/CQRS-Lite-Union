using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Common.Response;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Utils
{
    public abstract class CommandHandlerBase<TRequest> : IRequestHandler<TRequest, IResponse> where TRequest : IRequest<IResponse>
    {
        protected IAppContext Context { get; private set; }

        public CommandHandlerBase(IAppContext context)
        {
            context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            IResponse response;
            try
            {
                Context.BeginTransaction();

                response = await HandleAsync(request, cancellationToken);

                Context.CommitTransaction();
            }
            catch (Exception ex)
            {
                // log exception
                Context.RollBackTransaction();
                throw;
            }

            return response;
        }

        protected abstract Task<IResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}
