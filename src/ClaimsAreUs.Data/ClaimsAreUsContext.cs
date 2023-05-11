using ClaimsAreUs.Data.Models;
using ClaimsAreUs.Data.Support;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAreUs.Data
{
    public class ClaimsAreUsContext : DbContext
    {
        public ClaimsAreUsContext(DbContextOptions<ClaimsAreUsContext> options)
            : base(options)
        {
        }

        public DbSet<Claim> Claims { get; set; } = null!;
        public DbSet<ClaimType> ClaimTypes { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply type configurations from the specified assembly
            modelBuilder.ApplyConfigurationsFromAssembly(DataAssemblyReference.Assembly);

            var tenYearsAgo = DateTime.UtcNow.AddYears(-10);

            #region Seeding

            // Presumed not correct in terms of real claim types but general headings taken 
            // from here: https://uk.markel.com/claims
            modelBuilder.Entity<ClaimType>()
                .HasData(
                    new ClaimType
                    {
                        Id = 1,
                        Name = "Legal Expense"
                    },
                    new ClaimType
                    {
                        Id = 2,
                        Name = "Liability"
                    },
                    new ClaimType
                    {
                        Id = 3,
                        Name = "Property"
                    },
                    new ClaimType
                    {
                        Id = 4,
                        Name = "Tax"
                    }
                );

            modelBuilder.Entity<Company>()
                .HasData(
                    new Company
                    {
                        Id = 1,
                        Name = "Dave's Dodgy Dealer",
                        Address1 = "1 Car Dealer Avenue",
                        Address2 = "Bradford",
                        PostCode = "BD1 1AA",
                        Country = "United Kingdom",
                        Active = true,
                        InsuranceEndDate = tenYearsAgo.AddYears(12) // Two years from now
                    },
                    new Company
                    {
                        Id = 2,
                        Name = "Brian's Bodged Bangers",
                        Address1 = "2 Car Dealer Avenue",
                        Address2 = "Bradford",
                        PostCode = "BD1 1AA",
                        Country = "United Kingdom",
                        Active = false,
                        InsuranceEndDate = tenYearsAgo.AddYears(9) // Last year
                    },
                    new Company
                    {
                        Id = 3,
                        Name = "Honest Chris' Cozy Cars",
                        Address1 = "3-100 Car Dealer Avenue", // We've expanded
                        Address2 = "Bradford",
                        PostCode = "BD1 1AA",
                        Country = "United Kingdom",
                        Active = true,
                        InsuranceEndDate = tenYearsAgo.AddYears(20) // Ten years from now. We can afford it.
                    }
                );

            modelBuilder.Entity<Claim>()
                .HasData(
                    // Dodgy Dave
                    new Claim
                    {
                        UCR = "UCR_4a0e5e71",
                        CompanyId = 1,
                        ClaimDate = tenYearsAgo.AddYears(1),
                        LossDate = tenYearsAgo.AddYears(1).AddDays(-1),
                        AssuredName = "Dave Dealer",
                        IncurredLoss = 4000m,
                        Closed = true
                    }, 
                    new Claim
                    {
                        UCR = "UCR_1deca533",
                        CompanyId = 1,
                        ClaimDate = tenYearsAgo.AddYears(5),
                        LossDate = tenYearsAgo.AddYears(5).AddDays(-5),
                        AssuredName = "Dave Dealer",
                        IncurredLoss = 10000m,
                        Closed = true
                    },
                    new Claim
                    {
                        UCR = "UCR_5f079de3",
                        CompanyId = 1,
                        ClaimDate = tenYearsAgo.AddYears(10),
                        LossDate = tenYearsAgo.AddYears(10).AddDays(-1),
                        AssuredName = "Dave Dealer",
                        IncurredLoss = 40000m,
                        Closed = false
                    },
                    
                    // Bodging Brian
                    new Claim
                    {
                        UCR = "UCR_0d2f71d2",
                        CompanyId = 2,
                        ClaimDate = tenYearsAgo.AddYears(3),
                        LossDate = tenYearsAgo.AddYears(3).AddDays(-3),
                        AssuredName = "Brian Bodger",
                        IncurredLoss = 400m,
                        Closed = true
                    }, 
                    new Claim
                    {
                        UCR = "UCR_8619246c",
                        CompanyId = 2,
                        ClaimDate = tenYearsAgo.AddYears(8),
                        LossDate = tenYearsAgo.AddYears(8).AddDays(-1),
                        AssuredName = "Brian Bodger",
                        IncurredLoss = 1000m,
                        Closed = true
                    },
                    new Claim
                    {
                        UCR = "UCR_921ab7c6",
                        CompanyId = 2,
                        ClaimDate = tenYearsAgo.AddYears(10),
                        LossDate = tenYearsAgo.AddYears(10).AddDays(-5),
                        AssuredName = "Brian Bodger",
                        IncurredLoss = 4000m,
                        Closed = false
                    }
                    
                    // Honest Chris has never claimed.
                );

            #endregion
        }
    }
}