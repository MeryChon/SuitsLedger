using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs
{
    public class SuitConfiguration : IEntityTypeConfiguration<Suit>
    {
        public void Configure(EntityTypeBuilder<Suit> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.RegistrationDate).IsRequired();

            builder.Property(s => s.LimitationPeriod).HasDefaultValue(30);

            builder.Property(s => s.Description).HasMaxLength(500);

            builder.HasOne(s => s.AuthorizedPerson).WithMany(ap => ap.Suits).HasForeignKey(s => s.AuthorizedPersonId);
        }
    }
}