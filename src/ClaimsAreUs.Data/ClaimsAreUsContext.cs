using ClaimsAreUs.Data.Models;
using ClaimsAreUs.Data.Support;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAreUs.Data
{
    public class ClaimsAreUsContext : DbContext
    {
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
        }
    }
}