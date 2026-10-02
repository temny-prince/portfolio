using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PW1.Models;

namespace PW1.Data.Configurations
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