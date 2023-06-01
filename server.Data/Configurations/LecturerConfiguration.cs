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
    public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
    {
        public void Configure(EntityTypeBuilder<Lecturer> builder)
        {
            builder.ToTable("Lecturer");

            builder.HasKey(x => x.IdLecturer);

            builder.HasOne(x => x.AppUser).WithOne(x => x.Lecturer).HasForeignKey<Lecturer>(x => x.IdUser);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
