using ClaimsAreUs.Common.Abstract;
using ClaimsAreUs.Domain.Features.Companies.Responses;
using MediatR;

namespace ClaimsAreUs.Domain.Features.Companies.Queries.ClaimsByCompanyIdAndClaimId
{
    /// <summary>
    ///     Claims by Company ID Query
    /// </summary>
    public sealed record ClaimByCompanyIdAndClaimIdQuery : IRequest<ClaimBasicResponseDto>, ITrackableRequest
    {
        /// <summary>
        ///     Unique identifier for company
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        ///     Unique identifier for claim
        /// </summary>
        public string ClaimId { get; set; } = null!;

        /// <summary>
        ///     Correlation id for tracking requests
        /// </summary>
        public string CorrelationId { get; set; } = null!;
    }
}