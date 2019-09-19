using CQRS_Lite_Union_API.Domain.Workshops;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS_Lite_Union_API.Persist.Sql.Configurations
{
    public class WorkshopEntityTypeConfiguration : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Metadata.FindNavigation(nameof(Workshop.Attendees)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
