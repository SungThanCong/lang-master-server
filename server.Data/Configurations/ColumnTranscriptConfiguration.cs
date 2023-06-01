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
    public class ColumnTranscriptConfiguration : IEntityTypeConfiguration<ColumnTranscript>
    {
        public void Configure(EntityTypeBuilder<ColumnTranscript> builder)
        {
            builder.ToTable("ColumnTranscript");

            builder.HasKey(x => x.IdColumn);

            builder.Property(x => x.Min).IsRequired();
            builder.Property(x => x.Max).IsRequired();
            builder.Property(x => x.Min).IsRequired();

        }
    }
}
