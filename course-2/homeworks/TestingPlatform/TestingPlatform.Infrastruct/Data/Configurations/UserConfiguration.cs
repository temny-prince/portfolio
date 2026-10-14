using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> e)
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.Login).IsRequired();

            e.Property(x => x.PasswordHash).IsRequired();

            e.Property(x => x.Email).IsRequired();

            e.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

            e.Property(x => x.LastName).IsRequired();

            e.Property(x => x.Role).HasConversion<string>().IsRequired();

            e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();

            e.HasIndex(x => x.Login).IsUnique();

            e.HasIndex(x => x.Email).IsUnique();

            e.HasOne(x => x.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}