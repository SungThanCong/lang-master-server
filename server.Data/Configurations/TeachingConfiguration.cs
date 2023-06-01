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
    public class TeachingConfiguration : IEntityTypeConfiguration<Teaching>
    {
        public void Configure(EntityTypeBuilder<Teaching> builder)
        {
            builder.ToTable("Teaching");

            builder.HasKey(x => new { x.IdLecturer, x.IdClass });

            builder.HasOne(x=>x.Lecturer).WithMany(x => x.Teachings).HasForeignKey(x => x.IdLecturer);

            builder.HasOne(x => x.Class).WithMany(x => x.Teachings).HasForeignKey(x => x.IdClass);
        }
    }
}
