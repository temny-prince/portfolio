using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Data.Configurations
{
    public class TestResultConfiguration : IEntityTypeConfiguration<TestResult>
    {
        public void Configure(EntityTypeBuilder<TestResult> e)
        {
            e.HasKey(x => x.Id);

            e.HasIndex(x => new { x.TestId, x.StudentId, x.AttemptId }).IsUnique();

            e.HasOne(x => x.Test)
                .WithMany()
                .HasForeignKey(x => x.TestId)
            .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(x => x.Attempt)
                .WithMany()
                .HasForeignKey(x => x.AttemptId)
            .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Student)
                .WithMany(s => s.TestResults)
                .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}