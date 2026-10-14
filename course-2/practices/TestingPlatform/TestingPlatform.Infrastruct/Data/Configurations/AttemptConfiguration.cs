using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Data.Configurations
{
    public class AttemptConfiguration : IEntityTypeConfiguration<Attempt>
    {
        public void Configure(EntityTypeBuilder<Attempt> e)
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.StartedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();

            e.HasOne(x => x.Test)
                .WithMany()
                .HasForeignKey(x => x.TestId)
            .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(x => x.Student)
                .WithMany(s => s.Attempts)
                .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

            e.HasMany(x => x.UserAttemptAnswers)
                .WithOne(a => a.Attempt)
                .HasForeignKey(a => a.AttemptId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}