using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PW1.Models;
using PW1.Models.JoinTablesModels;

namespace PW1.Data.Configurations
{
    public class TestProjectConfiguration : IEntityTypeConfiguration<TestProject>
    {
        public void Configure(EntityTypeBuilder<TestProject> e)
        {
            e.ToTable("test_projects");
            e.HasKey(x => new { x.TestId, x.ProjectId });

            e.HasOne(x => x.Test)
                .WithMany(t => t.TestProjects)
                .HasForeignKey(x => x.TestId)
            .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Project)
                .WithMany(p => p.TestProjects)
                .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}