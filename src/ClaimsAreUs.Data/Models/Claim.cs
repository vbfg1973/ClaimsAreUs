using System.ComponentModel.DataAnnotations;

namespace ClaimsAreUs.Data.Models
{
    /// <summary>
    ///     Claims data model
    /// </summary>
    public class Claim
    {
        /// <summary>
        ///     Primary key for this table. Defined in the Type Configuration rather than here
        /// </summary>
        [StringLength(20)]
        public string UCR { get; set; } = null!;

        /// <summary>
        ///     Foreign key to Company table
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        ///     Company navigation property
        /// </summary>
        public Company Company { get; set; } = null!;

        /// <summary>
        ///     Date claim is made
        /// </summary>
        public DateTime ClaimDate { get; set; }

        /// <summary>
        ///     Date claimed loss occurred
        /// </summary>
        public DateTime LossDate { get; set; }

        /// <summary>
        ///     The name of the person protected by the policy
        /// </summary>
        [StringLength(100)]
        public string AssuredName { get; set; } = null!;

        /// <summary>
        ///     The amount claimed
        /// </summary>
        public decimal IncurredLoss { get; set; }

        /// <summary>
        ///     Claim now closed?
        /// </summary>
        public bool Closed { get; set; }

        #region Needed but not actually described in spec/requirements so deliberately missing out

        // /// <summary>
        // ///     Foreign key to ClaimType table
        // /// </summary>
        // public int ClaimTypeId { get; set; }
        //
        // /// <summary>
        // ///     ClaimType navigation property
        // /// </summary>
        // public ClaimType ClaimType { get; set; } = null!;

        #endregion
    }
}