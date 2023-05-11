using ClaimsAreUs.Common.Abstract;
using ClaimsAreUs.Domain.Features.Companies.Responses;
using MediatR;

namespace ClaimsAreUs.Domain.Features.Companies.Queries.ClaimsByComapnyId
{
    /// <summary>
    ///     Claims by Company ID Query
    /// </summary>
    public sealed record ClaimsByCompanyIdQuery : IRequest<IEnumerable<ClaimBasicResponseDto>>, ITrackableRequest
    {
        /// <summary>
        ///     Unique identifier for company
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        ///     Correlation id for tracking requests
        /// </summary>
        public string CorrelationId { get; set; } = null!;
    }
}