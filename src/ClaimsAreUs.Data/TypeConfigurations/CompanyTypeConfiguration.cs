using ClaimsAreUs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimsAreUs.Data.TypeConfigurations
{
    public class CompanyTypeConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // Would be picked up by EF conventions but, if defined in some, I prefer to define in all for consistency
            builder.HasKey(company => company.Id);
        }
    }
}