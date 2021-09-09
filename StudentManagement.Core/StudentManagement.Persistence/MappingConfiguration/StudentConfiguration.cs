using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domaine.Entities;

namespace StudentManagement.Persistence.MappingConfiguration
{
    public class StudentConfiguration: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
              builder.ToTable("Students", schema: "hr");
              builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
        }
    }
}