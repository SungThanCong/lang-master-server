using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var roleId1 = new Guid("0FCBB353-AE6B-4936-9FDD-950EFEB452A6");
            var roleId2 = new Guid("09480504-4C27-4AF7-A492-ADCDBBE6C097");

            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"
                },
                new AppRole
                {
                    Id = roleId1,
                    Name = "lecturer",
                    NormalizedName = "lecturer",
                    Description = "Lecturer role"
                },
                new AppRole
                {
                    Id = roleId2,
                    Name = "employee",
                    NormalizedName = "employee",
                    Description = "Employee role"
                }
            );

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "chinh.admin@gmail.com",
                NormalizedEmail = "chinh.admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                DisplayName = "Luu Le Ba Chinh",
                Dob = new DateTime(2000, 01, 31),
                Address="Quang Nam"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
