using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Data.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> e)
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.Title).IsRequired();
            e.Property(x => x.Description).IsRequired();
            e.Property(x => x.IsRepeatable).HasDefaultValue(false);
            e.Property(x => x.IsPublic).HasDefaultValue(false);
            e.Property(x => x.Type).HasConversion<string>().IsRequired();
            e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
            e.Property(x => x.PublishedAt).IsRequired();
            e.Property(x => x.Deadline).IsRequired();

            e.HasMany(x => x.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}