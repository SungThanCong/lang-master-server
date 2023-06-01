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
    public class TestingConfiguration : IEntityTypeConfiguration<Testing>
    {
        public void Configure(EntityTypeBuilder<Testing> builder)
        {
            builder.ToTable("Testing");

            builder.HasKey(x => new { x.IdStudent, x.IdExam });

            builder.Property(x => x.Score).HasDefaultValue(0).IsRequired();

            builder.HasOne(x => x.Exam).WithMany(x => x.Testings).HasForeignKey(x => x.IdExam);

            builder.HasOne(x => x.Student).WithMany(x => x.Testings).HasForeignKey(x => x.IdStudent);
        }
    }
}
