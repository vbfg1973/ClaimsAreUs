using AutoMapper;
using ClaimsAreUs.Common.Abstract;
using ClaimsAreUs.Common.Logging;
using ClaimsAreUs.Data;
using ClaimsAreUs.Domain.Exceptions;
using ClaimsAreUs.Domain.Features.Companies.Responses;
using CustomerManagement.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

    /// <summary>
    ///     Handler for Claims by Company ID
    /// </summary>
    public class ClaimsByCompanyIdQueryHandler : 
        IRequestHandler<ClaimsByCompanyIdQuery, IEnumerable<ClaimBasicResponseDto>>
    {
        private readonly ClaimsAreUsContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ClaimsByCompanyIdQueryHandler> _logger;

        /// <summary>
        ///     ctor
        /// </summary>
        public ClaimsByCompanyIdQueryHandler(ClaimsAreUsContext context, 
            IMapper mapper, 
            ILogger<ClaimsByCompanyIdQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        ///     Handles the request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClaimBasicResponseDto>> Handle(ClaimsByCompanyIdQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogDebug("{Message} {CorrelationId}", LogFmt.Message($"Attempting to get list of claims for company identified by {request.CompanyId}"), LogFmt.CorrelationId(request));

            if (!_context.Companies.Any(company => company.Id == request.CompanyId))
                throw new ResourceNotFoundException(ExceptionMessages.CompanyDoesNotExist);
            
            var queryable = _context.Claims.Where(claim => claim.CompanyId == request.CompanyId);

            var results = await _mapper.ProjectTo<ClaimBasicResponseDto>(queryable).ToListAsync(cancellationToken: cancellationToken);
            
            _logger.LogDebug("{Message} {CorrelationId}", LogFmt.Message($"Attempting to get list of claims for company identified by {request.CompanyId}"), LogFmt.CorrelationId(request));

            return results;
        }
    }
}