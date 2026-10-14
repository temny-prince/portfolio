using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> e)
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
        }
    }
}