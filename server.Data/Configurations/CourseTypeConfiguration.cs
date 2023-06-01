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
    public class CourseTypeConfiguration : IEntityTypeConfiguration<CourseType>
    {
        public void Configure(EntityTypeBuilder<CourseType> builder)
        {
            builder.ToTable("CourseType");

            builder.HasKey(x => x.IdCourseType);

            builder.Property(x => x.TypeName).HasMaxLength(255).IsRequired();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
