using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configs
{
    public class AuthorizedPersonConfiguration : IEntityTypeConfiguration<AuthorizedPerson>
    {
        public void Configure(EntityTypeBuilder<AuthorizedPerson> builder)
        {
            builder.HasKey(ap => ap.Id);

            builder
            .Property(ap => ap.IdentificationNumber)
            .IsRequired()
            .HasMaxLength(16);

            builder.Property(ap => ap.FirstName).HasMaxLength(128);

            builder.Property(ap => ap.LastName).HasMaxLength(128);

            builder.Property(ap => ap.Name).HasMaxLength(256);


        }
    }
}