using CQRS_Lite_Union_API.Domain.Workshops;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Persist.Sql.Configurations
{
    public class WorkshopEntityTypeConfiguration : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            throw new NotImplementedException();
        }
    }
}
