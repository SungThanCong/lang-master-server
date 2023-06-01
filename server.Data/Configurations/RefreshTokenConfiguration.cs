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
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshTokens>
    {
        public void Configure(EntityTypeBuilder<RefreshTokens> builder)
        {
            builder.ToTable("RefreshTokens");

            builder.HasKey("Id");

            builder.Property("CreatedAt").HasDefaultValue(DateTime.Now);

            builder.Property("UpdateAt").HasDefaultValue(DateTime.Now);


            builder.HasOne(x => x.AppUser).WithOne(x => x.RefreshTokens).HasForeignKey<RefreshTokens>(x=>x.IdUser);
        }
    }
}
