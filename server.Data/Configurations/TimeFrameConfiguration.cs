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
            builder.Property(x => x.StartingTime).IsRequired();
            builder.Property(x => x.EndingTime).IsRequired();
            builder.Property(x => x.Activate).HasDefaultValue(true);
        }
    }
}
