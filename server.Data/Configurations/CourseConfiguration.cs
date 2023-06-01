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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            builder.HasKey(x => x.IdCourse);

            builder.Property(x => x.CourseName).HasMaxLength(255).IsRequired();

            builder.Property(x => x.Fee).IsRequired();
            builder.Property(x => x.Max).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);


            builder.HasOne(x => x.Level).WithMany(x => x.Courses).HasForeignKey(x => x.IdLevel);

            builder.HasOne(x => x.CourseType).WithMany(x => x.Courses).HasForeignKey(x => x.IdCourseType);
        }
    }
}
