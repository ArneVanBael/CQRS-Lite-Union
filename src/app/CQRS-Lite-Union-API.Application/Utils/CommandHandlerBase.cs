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
        private readonly IAppContext _context;

        public CommandHandlerBase(IAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            IResponse response;
            try
            {
                StartDbTransaction();

                response = await HandleAsync(request, cancellationToken);

                CommitDbTransaction();
            }
            catch (Exception ex)
            {
                // log exception
                RollbackDbTransaction();
                throw;
            }

            return response;
        }

        private void StartDbTransaction()
        {
            if (_context.Database.CurrentTransaction != null) return;
            _context.Database.BeginTransaction();
        }

        private void RollbackDbTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        private void CommitDbTransaction()
        {
            _context.Database.CommitTransaction();
        }

        protected abstract Task<IResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}
