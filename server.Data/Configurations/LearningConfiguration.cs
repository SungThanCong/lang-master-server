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
    public class LearningConfiguration : IEntityTypeConfiguration<Learning>
    {
        public void Configure(EntityTypeBuilder<Learning> builder)
        {
            builder.ToTable("Learning");

            builder.HasKey(x => new { x.IdStudent, x.IdClass });

            builder.HasOne(x => x.Student).WithMany(x => x.Learnings).HasForeignKey(x => x.IdStudent);

            builder.HasOne(x => x.Class).WithMany(x => x.Learnings).HasForeignKey(x => x.IdClass);
        }
    }
}
