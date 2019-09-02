using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Common.Options;
using CQRS_Lite_Union_API.Domain.Attendees;
using CQRS_Lite_Union_API.Domain.Workshops;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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

        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
    }
}
