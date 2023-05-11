using ClaimsAreUs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimsAreUs.Data.TypeConfigurations
{
    public class ClaimTypeTypeConfiguration : IEntityTypeConfiguration<ClaimType>
    {
        public void Configure(EntityTypeBuilder<ClaimType> builder)
        {
            // Would be picked up by EF conventions but, if defined in some, I prefer to define in all for consistency
            builder.HasKey(claimType => claimType.Id);
        }
    }
}