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
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendance");

            builder.HasKey(x => new { x.IdStudent, x.IdClassTime });

            builder.HasOne(x => x.Student).WithMany(x => x.Attendances).HasForeignKey(x => x.IdStudent);

            builder.HasOne(x => x.ClassTime).WithMany(x => x.Attendances).HasForeignKey(x => x.IdClassTime);
        }
    }
}
