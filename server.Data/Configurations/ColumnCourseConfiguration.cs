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
    public class ColumnCourseConfiguration : IEntityTypeConfiguration<ColumnCourse>
    {
        public void Configure(EntityTypeBuilder<ColumnCourse> builder)
        {
            builder.ToTable("ColumnCourse");

            builder.HasKey(x => new { x.IdCourse, x.IdColumn });

            builder.HasOne(x => x.Course).WithMany(x => x.ColumnCourses).HasForeignKey(x=>x.IdCourse);

            builder.HasOne(x => x.ColumnTranscript).WithMany(x => x.ColumnCourses).HasForeignKey(x=>x.IdColumn);

        }
    }
}
