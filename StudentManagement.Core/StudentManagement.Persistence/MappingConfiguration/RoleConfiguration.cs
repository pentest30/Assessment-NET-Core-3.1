using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domaine.Entities;

namespace StudentManagement.Persistence.MappingConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //builder.ToTable("Roles", schema: "identity");
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            // builder.HasMany(x => x.UserRoles)
            //     .WithOne(x => x.Role)
            //     .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(new List<Role>
            {
                new Role
                {
                    Id = Guid.Parse("b512f030-544c-eb11-9ce0-a4c3f0d0208b"),
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin".ToUpper()

                },
                new Role
                {
                    Id = Guid.Parse("b512f030-554c-eb11-9ce0-a4c3f0d0208b"),
                    Name = "Teacher",
                    NormalizedName = "Teacher".ToUpper()

                },
                new Role
                {
                    Id = Guid.Parse("b512f030-546c-eb11-9ce0-a4c3f0d0208b"),
                    Name = "HumanResource",
                    NormalizedName = "HumanResource".ToUpper()

                },
            });
        }
    }


}