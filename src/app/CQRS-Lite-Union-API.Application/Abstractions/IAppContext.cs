using CQRS_Lite_Union_API.Domain.Attendees;
using CQRS_Lite_Union_API.Domain.Workshops;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.Application.Abstractions
{
    public interface IAppContext
    {
        DatabaseFacade Database { get; }
        DbSet<Workshop> Workshops { get; set; }
        DbSet<Attendee> Attendees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
