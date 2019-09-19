using CQRS_Lite_Union_API.Domain.Attendees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Persist.Sql.Configurations
{
    public class AttendeeEntityTypeConfiguration : IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Created).IsRequired();
            builder.HasOne(x => x.Workshop).WithMany(x => x.Attendees).HasForeignKey(x => x.WorkshopId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
