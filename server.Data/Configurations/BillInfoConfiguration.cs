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
    public class BillInfoConfiguration : IEntityTypeConfiguration<BillInfo>
    {
        public void Configure(EntityTypeBuilder<BillInfo> builder)
        {
            builder.ToTable("BillInfo");

            builder.HasKey(x => new {x.IdBill, x.IdCourse});

            builder.HasOne(x => x.Bill).WithMany(x => x.BillInfos).HasForeignKey(x => x.IdBill);

            builder.HasOne(x => x.Course).WithMany(x => x.BillInfos).HasForeignKey(x => x.IdCourse);

        }
    }
}
