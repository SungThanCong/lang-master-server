using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Configurations
{
    public class TimeFrameConfiguration : IEntityTypeConfiguration<TimeFrame>
    {
        public void Configure(EntityTypeBuilder<TimeFrame> builder)
        {
            builder.ToTable("TimeFrame");

            builder.HasKey(x => x.IdTimeFrame);
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.Active).HasDefaultValue(false);
        }
    }
}
