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
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.IdEmployee);

            builder.HasOne(x => x.AppUser).WithOne(x => x.Employee).HasForeignKey<Employee>(x => x.IdUser).IsRequired();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
