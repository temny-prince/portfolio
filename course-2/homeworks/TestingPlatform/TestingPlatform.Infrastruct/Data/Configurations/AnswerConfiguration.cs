using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Data.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> e)
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.Text).IsRequired();
            e.Property(x => x.IsCorrect).IsRequired();
        }
    }
}