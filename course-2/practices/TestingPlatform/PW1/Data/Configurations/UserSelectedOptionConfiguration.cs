using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PW1.Models;

namespace PW1.Data.Configurations
{
    public class UserSelectedOptionConfiguration : IEntityTypeConfiguration<UserSelectedOption>
    {
        public void Configure(EntityTypeBuilder<UserSelectedOption> e)
        {
            e.HasKey(x => x.Id);

            e.HasOne(x => x.Answer)
                .WithMany(a => a.UserSelectedOptions)
                .HasForeignKey(x => x.AnswerId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}