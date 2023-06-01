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
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("Level");

            builder.HasKey(x => x.IdLevel);

            builder.Property(x => x.LevelName).HasMaxLength(128).IsRequired();

            builder.Property(x => x.Point).HasDefaultValue(0).IsRequired();

            builder.Property(x => x.Language).HasMaxLength(128).IsRequired();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
