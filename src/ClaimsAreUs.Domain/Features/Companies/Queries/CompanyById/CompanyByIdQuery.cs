using ClaimsAreUs.Common.Abstract;
using ClaimsAreUs.Domain.Features.Companies.Responses;
using MediatR;

namespace ClaimsAreUs.Domain.Features.Companies.Queries.CompanyById
{
    /// <summary>
    ///     Company by id query
    /// </summary>
    public sealed record CompanyByIdQuery : IRequest<CompanyBasicResponseDto>, ITrackableRequest
    {
        /// <summary>
        ///     Company unique identifier
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        ///     Correlation id for tracking requests
        /// </summary>
        public string CorrelationId { get; set; } = null!;
    }
}