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
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");

            builder.HasKey(x=> x.IdBill);

            builder.HasOne(x => x.Employee).WithMany(x => x.Bills).HasForeignKey(x => x.IdEmployee);
            builder.HasOne(x => x.Student).WithMany(x => x.Bills).HasForeignKey(x => x.IdStudent);

            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
