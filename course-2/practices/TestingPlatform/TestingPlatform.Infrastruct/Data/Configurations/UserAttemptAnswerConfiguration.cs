using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Data.Configurations
{
    public class UserAttemptAnswerConfiguration : IEntityTypeConfiguration<UserAttemptAnswer>
    {
        public void Configure(EntityTypeBuilder<UserAttemptAnswer> e)
        {
            e.HasKey(x => x.Id);

            e.HasIndex(x => new { x.AttemptId, x.QuestionId }).IsUnique();

            e.HasOne(x => x.Question)
                .WithMany(q => q.UserAttemptAnswers)
                .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);

            e.HasMany(x => x.UserSelectedOptions)
                .WithOne(o => o.UserAttemptAnswer)
                .HasForeignKey(o => o.UserAttemptAnswerId)
            .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.UserTextAnswer)
                .WithOne(t => t.UserAttemptAnswer)
                .HasForeignKey<UserTextAnswer>(t => t.UserAttemptAnswerId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}