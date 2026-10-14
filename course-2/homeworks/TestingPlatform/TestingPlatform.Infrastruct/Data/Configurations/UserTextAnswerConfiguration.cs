using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Data.Configurations
{
    public class UserTextAnswerConfiguration : IEntityTypeConfiguration<UserTextAnswer>
    {
        public void Configure(EntityTypeBuilder<UserTextAnswer> e)
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.TextAnswer).IsRequired();
        }
    }
}