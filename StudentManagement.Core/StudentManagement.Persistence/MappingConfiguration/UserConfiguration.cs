using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domaine.Entities;

namespace StudentManagement.Persistence.MappingConfiguration
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
         //   builder.ToTable("Users", schema: "identity");
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            // builder.HasMany(x => x.UserRoles)
            //     .WithOne(x => x.User)
            //     .OnDelete(DeleteBehavior.Cascade);
            // Seed
            builder.HasData(new List<User>
            {
                new User
                {
                    Id = Guid.Parse("12837D3D-793F-EA11-BECB-5CEA1D05F660"),
                    UserName = "admin",
                    NormalizedUserName = "admin".ToUpper(),
                    Email = "Admin@gmail.com",
                    NormalizedEmail = "Admin@admin.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEEjYGaTgBROnY9mpeyZy6Imme/lvja+QHRHHp8f/r3kf50njFkEo9L8LoKeJP7XCEg==", // abcd$001
                    SecurityStamp = "E2RDVSK6IIYBIP5OJOHTPGWZVD6NMIB6",
                    EmailConfirmed = true,

                },
            });
        }
    }
}