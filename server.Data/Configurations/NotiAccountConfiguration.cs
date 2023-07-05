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
    public class NotiAccountConfiguration : IEntityTypeConfiguration<Noti_Account>
    {
        public void Configure(EntityTypeBuilder<Noti_Account> builder)
        {
            builder.ToTable("NotiAccount");

            builder.HasKey(x => new { x.IdNotification, x.IdAccount });

            builder.HasOne(x => x.AppUser).WithMany(x => x.NotiAccounts).HasForeignKey(x => x.IdAccount);

            builder.HasOne(x => x.Notification).WithMany(x => x.NotiAccounts).HasForeignKey(x => x.IdNotification);
        }
    }
}
