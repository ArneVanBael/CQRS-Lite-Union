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
            throw new NotImplementedException();
        }
    }
}
