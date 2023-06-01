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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exam");

            builder.HasKey(x => x.IdExam);

            builder.HasOne(x => x.Class).WithMany(x => x.Exams).HasForeignKey(x => x.IdClass);

            builder.HasOne(x => x.ColumnTranscript).WithMany(x => x.Exams).HasForeignKey(x => x.IdColumn);

            builder.HasOne(x => x.TestType).WithMany(x => x.Exams).HasForeignKey(x => x.IdTestType);

            builder.Property(x => x.PostedDate).HasDefaultValue(DateTime.Now);

            builder.Property(x => x.ExamName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.FileUrl).IsRequired();
            builder.Property(x => x.TestTime).IsRequired();
            builder.Property(x => x.TestDate).IsRequired();

        }
    }
}
