using System.ComponentModel.DataAnnotations;

namespace ClaimsAreUs.Data.Models
{
    /// <summary>
    ///     The policy holding companies which are able to make claims
    /// </summary>
    public class Company
    {
        /// <summary>
        ///     The primary key. Will be picked up by conventions but I prefer to define in the Type Configuration
        ///     when there are any that need to be. Consistency of approach throughout is always a benefit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The name of the company
        /// </summary>
        [StringLength(200)]
        public string Name { get; set; } = null!;

        /// <summary>
        ///     First address line. By PAF standards this is the only one that is a MUST
        /// </summary>
        [StringLength(100)]
        public string Address1 { get; set; } = null!;

        /// <summary>
        ///     Second address line. Desired but not required.
        /// </summary>
        [StringLength(100)]
        public string? Address2 { get; set; }

        /// <summary>
        ///     Third address line. Desired but not required.
        /// </summary>
        [StringLength(100)]
        public string? Address3 { get; set; }

        /// <summary>
        ///     Postal code.
        /// </summary>
        [StringLength(20)]
        public string PostCode { get; set; } = null!;

        /// <summary>
        ///     The country of the address of the company
        /// </summary>
        [StringLength(50)]
        public string Country { get; set; } = null!;

        /// <summary>
        ///     Policy is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///     Date the company's policy ends
        /// </summary>
        public DateTime InsuranceEndDate { get; set; }

        /// <summary>
        ///     Navigation property to claims for this company
        /// </summary>
        public List<Claim> Claims { get; set; } = new();
    }
}