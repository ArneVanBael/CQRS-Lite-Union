using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Common.Options;
using CQRS_Lite_Union_API.Domain.Attendees;
using CQRS_Lite_Union_API.Domain.Workshops;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;

namespace CQRS_Lite_Union_API.Persist.Sql
{
    public class AppContext : DbContext, IAppContext
    {
        private readonly ConnectionStrings _options;

        public AppContext()
        {

        }

        public AppContext(IOptions<ConnectionStrings> options)
        {
            _options = options.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_options.CQRSLiteUnionDb);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }

        public void BeginTransaction()
        {
            if (Database.CurrentTransaction != null) return;
            Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            Database.RollbackTransaction();
        }

        public void DatabaseEnsureCreated()
        {
            Database.EnsureCreated();
        }

        private DbSet<Workshop> Workshops { get; set; }
        public IQueryable<Workshop> WorkshopsQueryRepository => Workshops.AsNoTracking();
        public DbSet<Workshop> WorkshopsCommandRepository => Workshops;
        
        private DbSet<Attendee> Attendees { get; set; }
        public IQueryable<Attendee> AttendeeQueryRepository => Attendees.AsNoTracking();
        public DbSet<Attendee> AttendeeCommandRepository => Attendees;
    }
}
