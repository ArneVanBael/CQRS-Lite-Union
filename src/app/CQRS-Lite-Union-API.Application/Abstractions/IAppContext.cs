using CQRS_Lite_Union_API.Domain.Attendees;
using CQRS_Lite_Union_API.Domain.Workshops;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Abstractions
{
    public interface IAppContext : IDisposable
    {
        IQueryable<Workshop> WorkshopsQueryRepository { get; }
        DbSet<Workshop> WorkshopsCommandRepository { get; }

        IQueryable<Attendee> AttendeeQueryRepository { get; }
        DbSet<Attendee> AttendeeCommandRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void DatabaseEnsureCreated();

        void BeginTransaction();
        void RollBackTransaction();
        void CommitTransaction();
    }
}
