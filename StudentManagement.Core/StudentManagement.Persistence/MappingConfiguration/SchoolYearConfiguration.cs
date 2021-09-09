using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domaine.Entities;

namespace StudentManagement.Persistence.MappingConfiguration
{
    public class SchoolYearConfiguration: IEntityTypeConfiguration<SchoolYear>
    {
        public void Configure(EntityTypeBuilder<SchoolYear> builder)
        {
            builder.ToTable("SchoolYears", schema: "settings");
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            builder.HasData(new List<SchoolYear>
            {
                new SchoolYear
                {
                    Id = Guid.Parse("11737D3D-793F-EA11-BECB-5CEA1D05F660"),
                    Name = "2021-2022", 
                    Value = 2021
                    
                },
                new SchoolYear
                {
                    Id = Guid.Parse("21937D3D-793F-EA11-BECB-5CEA1D05F660"),
                    Name = "2022-2023",
                    Value = 2022
                    
                },
            });
        }
    }
}