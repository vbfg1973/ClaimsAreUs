using ClaimsAreUs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimsAreUs.Data.TypeConfigurations
{
    public class ClaimTypeConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.HasKey(claim => claim.UCR);

            builder.Property(claim => claim.IncurredLoss).HasPrecision(15, 2);
        }
    }
}