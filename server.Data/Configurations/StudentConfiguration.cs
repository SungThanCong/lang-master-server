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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(x => x.IdStudent);

            builder.HasOne(x => x.AppUser).WithOne(x => x.Student).HasForeignKey<Student>(x=>x.IdUser).IsRequired();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            
        }
    }
}
