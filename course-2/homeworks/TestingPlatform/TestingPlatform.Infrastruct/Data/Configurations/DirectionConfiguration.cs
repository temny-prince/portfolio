using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Data.Configurations
{
    public class DirectionConfiguration : IEntityTypeConfiguration<Direction>
    {
        public void Configure(EntityTypeBuilder<Direction> e)
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
        }
    }
}