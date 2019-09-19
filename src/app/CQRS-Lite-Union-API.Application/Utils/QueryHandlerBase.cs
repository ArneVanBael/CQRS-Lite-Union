using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Common.Response;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Utils
{
    public abstract class QueryHandlerBase<TQuery, TResult> : IRequestHandler<TQuery, IResponse<TResult>> where TQuery : IRequest<IResponse<TResult>>
    {
        protected IAppContext Context { get; private set; }

        public QueryHandlerBase(IAppContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IResponse<TResult>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            IResponse<TResult> response;
            try
            {
                response = await HandleAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                // log exception
                throw;
            }

            return response;
        }

        protected abstract Task<IResponse<TResult>> HandleAsync(TQuery request, CancellationToken cancellationToken);
    }
}
