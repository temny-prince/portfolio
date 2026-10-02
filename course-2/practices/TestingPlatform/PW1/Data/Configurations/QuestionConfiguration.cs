using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PW1.Models;

namespace PW1.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> e)
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.Text).IsRequired();

            e.Property(x => x.Number).IsRequired();

            e.Property(x => x.Description).HasMaxLength(2000);

            e.Property(x => x.AnswerType).HasConversion<string>().IsRequired();

            e.Property(x => x.IsScoring).HasDefaultValue(true);

            e.HasIndex(x => new { x.TestId, x.Number }).IsUnique();

            e.HasMany(x => x.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}