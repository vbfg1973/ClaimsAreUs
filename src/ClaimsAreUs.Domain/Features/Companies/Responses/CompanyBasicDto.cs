namespace ClaimsAreUs.Domain.Features.Companies.Responses
{
    /// <summary>
    ///     Basic company details
    /// </summary>
    public class CompanyBasicDto
    {
        /// <summary>
        ///     Company unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The name of the company
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        ///     First address line. By PAF standards this is the only one that is a MUST
        /// </summary>
        public string Address1 { get; set; } = null!;

        /// <summary>
        ///     Second address line. Desired but not required.
        /// </summary>
        public string? Address2 { get; set; }

        /// <summary>
        ///     Third address line. Desired but not required.
        /// </summary>
        public string? Address3 { get; set; }

        /// <summary>
        ///     Postal code.
        /// </summary>
        public string PostCode { get; set; } = null!;

        /// <summary>
        ///     The country of the address of the company
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        ///     Policy is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///     Date the company's policy ends
        /// </summary>
        public DateTime InsuranceEndDate { get; set; }
    }
}