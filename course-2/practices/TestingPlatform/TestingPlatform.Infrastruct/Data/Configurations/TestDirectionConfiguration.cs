using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;
using TestingPlatform.Domain.Models.Enums;

namespace TestingPlatform.Data.Configurations
{
    public class TestDirectionConfiguration : IEntityTypeConfiguration<TestDirection>
    {
        public void Configure(EntityTypeBuilder<TestDirection> e)
        {
            e.ToTable("test_directions");
            e.HasKey(x => new { x.TestId, x.DirectionId });

            e.HasOne(x => x.Test)
                .WithMany(t => t.TestDirections)
                .HasForeignKey(x => x.TestId)
            .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Direction)
                .WithMany(d => d.TestDirections)
                .HasForeignKey(x => x.DirectionId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}