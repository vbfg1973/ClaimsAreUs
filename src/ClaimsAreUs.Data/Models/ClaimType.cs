using System.ComponentModel.DataAnnotations;

namespace ClaimsAreUs.Data.Models
{
    /// <summary>
    ///     The types of claim supported. Whilst it seems obvious (one-to-one from Claim to ClaimType)
    ///     there is nothing in the specification about how this should be modelled or accessed via any
    ///     of the proposed routes. I am therefore including it here, seeding it with sample data and providing a
    ///     DbSet in the DbContext but otherwise it will remain untouched.
    /// </summary>
    public class ClaimType
    {
        /// <summary>
        ///     The primary key. Will be picked up by conventions but I prefer to define in the Type Configuration
        ///     when there are any that need to be. Consistency of approach throughout is always a benefit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The name of the claim type.
        /// </summary>
        [StringLength(20)]
        public string Name { get; set; } = null!;

        #region Needed but not actually described in spec/requirements so deliberately missing out

        // /// <summary>
        // ///     Claims navigation property
        // /// </summary>
        // public List<Claim> Claims { get; set; } = new();

        #endregion
    }
}