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
    public class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.ToTable("Parameter");

            builder.HasKey(x=>x.IdParameter);

            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(128).IsRequired();

        }
    }
}
