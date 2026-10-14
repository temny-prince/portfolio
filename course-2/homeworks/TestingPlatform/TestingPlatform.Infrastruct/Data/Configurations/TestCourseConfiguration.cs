using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;
using TestingPlatform.Domain.Models.Enums;

namespace TestingPlatform.Data.Configurations
{
    public class TestCourseConfiguration : IEntityTypeConfiguration<TestCourse>
    {
        public void Configure(EntityTypeBuilder<TestCourse> e)
        {
            e.ToTable("test_courses");
            e.HasKey(x => new { x.TestId, x.CourseId });

            e.HasOne(x => x.Test)
                .WithMany(t => t.TestCourses)
                .HasForeignKey(x => x.TestId)
            .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Course)
                .WithMany(c => c.TestCourses)
                .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}