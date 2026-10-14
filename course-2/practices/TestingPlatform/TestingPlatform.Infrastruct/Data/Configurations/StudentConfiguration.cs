using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;
namespace TestingPlatform.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> e)
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.Phone).IsRequired().HasMaxLength(30);

            e.Property(x => x.VkProfileLink).IsRequired();

            e.Property(x => x.UserId).IsRequired();

            e.HasIndex(x => x.UserId).IsUnique();

            e.HasMany(x => x.Groups)
                .WithMany(g => g.Students)
                .UsingEntity(j => j.ToTable("student_groups"));

            e.HasMany(x => x.Attempts)
                .WithOne(a => a.Student)
                .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

            e.HasMany(x => x.TestResults)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}