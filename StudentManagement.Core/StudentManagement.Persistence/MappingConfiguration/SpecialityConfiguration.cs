using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domaine.Entities;

namespace StudentManagement.Persistence.MappingConfiguration
{
    public class SpecialityConfiguration  : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable("Specialities", schema: "settings");
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            builder.HasData(new List<Speciality>
            {
                new Speciality
                {
                    Id = Guid.Parse("11837D3D-793F-EA11-BECB-5CEA1D05F660"),
                   Name = "Computer science", 
                   Description = "Computer science"
                    
                },
                new Speciality
                {
                    Id = Guid.Parse("21837D3D-793F-EA11-BECB-5CEA1D05F660"),
                    Name = "Medecine",
                    Description = "Medecine"
                    
                },
            });
        }
    }
}