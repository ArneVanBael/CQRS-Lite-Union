using CQRS_Lite_Union_API.Domain.Attendees;
using CQRS_Lite_Union_API.Domain.Workshops;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Abstractions
{
    public interface IAppContext
    {
        IQueryable<Workshop> WorkshopsQueryRepository { get; }
        IQueryable<Workshop> WorkshopsCommandRepository { get; }

        IQueryable<Attendee> AttendeeQueryRepository { get; }
        IQueryable<Attendee> AttendeeCommandRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void BeginTransaction();
        void RollBackTransaction();
        void CommitTransaction();
    }
}
