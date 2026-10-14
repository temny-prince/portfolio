using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;
using TestingPlatform.Domain.Models.Enums;

namespace TestingPlatform.Data.Configurations
{
    public class TestGroupConfiguration : IEntityTypeConfiguration<TestGroup>
    {
        public void Configure(EntityTypeBuilder<TestGroup> e)
        {
            e.ToTable("test_groups");

            e.HasKey(x => new { x.TestId, x.GroupId });

            e.HasOne(x => x.Test)
                .WithMany(t => t.TestGroups)
                .HasForeignKey(x => x.TestId)
            .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Group)
                .WithMany(g => g.TestGroups)
                .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}