using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;
using TestingPlatform.Domain.Models.Enums;

namespace TestingPlatform.Data.Configurations
{
    public class TestStudentConfiguration : IEntityTypeConfiguration<TestStudent>
    {
        public void Configure(EntityTypeBuilder<TestStudent> e)
        {
            e.ToTable("test_students");
            e.HasKey(x => new { x.TestId, x.StudentId });

            e.HasOne(x => x.Test)
                .WithMany(t => t.TestStudents)
                .HasForeignKey(x => x.TestId)
            .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Student)
                .WithMany(s => s.TestStudents)
                .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}