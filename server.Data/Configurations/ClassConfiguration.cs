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
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class");

            builder.HasKey(x => x.IdClass);

            builder.HasOne(x => x.Course).WithMany(x => x.Classes).HasForeignKey(x => x.IdCourse);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();

            builder.Property(x => x.ClassName).HasMaxLength(128).IsRequired();
        }
    }
}
