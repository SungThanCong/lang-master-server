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
    public class ClassTimeConfiguration : IEntityTypeConfiguration<ClassTime>
    {
        public void Configure(EntityTypeBuilder<ClassTime> builder)
        {
            builder.ToTable("ClassTime");

            builder.HasKey(x => x.IdClassTime);

            builder.HasOne(x => x.Class).WithMany(x => x.ClassTimes).HasForeignKey(x => x.IdClass);

            builder.HasOne(x => x.TimeFrame).WithMany(x => x.ClassTimes).HasForeignKey(x => x.IdTimeFrame);

            builder.Property(x => x.DayOfWeek).IsRequired();

        }
    }
}
