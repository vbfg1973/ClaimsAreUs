using ClaimsAreUs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimsAreUs.Data.TypeConfigurations
{
    public class ClaimTypeConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            // Non standard primary key that EF conventions would not detect.
            builder.HasKey(claim => claim.UCR);

            builder.Property(claim => claim.IncurredLoss).HasPrecision(15, 2);

            // Ordinarily EF conventions would pick this up. Entering here to show facility with the principles
            builder.HasOne<Company>(claim => claim.Company)
                .WithMany(company => company.Claims)
                .HasForeignKey(claim => claim.CompanyId);

            #region Needed but not actually described in spec/requirements so deliberately missing out

            // // Ordinarily EF conventions would pick this up. Entering here to show facility with the principles
            // builder.HasOne<ClaimType>(claim => claim.ClaimType)
            //     .WithMany(claimType => claimType.Claims)
            //     .HasForeignKey(claim => claim.ClaimTypeId);

            #endregion
        }
    }
}