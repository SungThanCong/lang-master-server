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
    public class ConfirmCodeConfiguration : IEntityTypeConfiguration<ConfirmCodes>
    {
        public void Configure(EntityTypeBuilder<ConfirmCodes> builder)
        {
            builder.ToTable("ConfirmCode");

            builder.HasKey(x => x.id);

            builder.HasOne(x => x.AppUser).WithMany(x => x.ConfirmCodes).HasForeignKey(x => x.IdUser);
        }
    }
}
