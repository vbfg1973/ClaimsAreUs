namespace ClaimsAreUs.Domain.Features.Companies.Responses
{
    /// <summary>
    /// </summary>
    public class ClaimBasicResponseDto
    {
        /// <summary>
        ///     Unique identifier for claim
        /// </summary>
        public string UCR { get; set; } = null!;

        /// <summary>
        ///     Date claim is made
        /// </summary>
        public DateTime ClaimDate { get; set; }

        /// <summary>
        ///     Number of days since claim was made
        /// </summary>
        public int DaysSinceClaim { get; set; }

        /// <summary>
        ///     Date claimed loss occurred
        /// </summary>
        public DateTime LossDate { get; set; }

        /// <summary>
        ///     Number of days since claimed loss occurred
        /// </summary>
        public int DaysSinceLoss { get; set; }

        /// <summary>
        ///     The name of the person protected by the policy
        /// </summary>
        public string AssuredName { get; set; } = null!;

        /// <summary>
        ///     The amount claimed
        /// </summary>
        public decimal IncurredLoss { get; set; }

        /// <summary>
        ///     Claim now closed?
        /// </summary>
        public bool Closed { get; set; }
    }
}