using AutoMapper;
using ClaimsAreUs.Common.Logging;
using ClaimsAreUs.Data;
using ClaimsAreUs.Domain.Exceptions;
using ClaimsAreUs.Domain.Features.Companies.Responses;
using CustomerManagement.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClaimsAreUs.Domain.Features.Companies.Queries.ClaimsByCompanyId
{
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

            var queryable = _context.Claims.Where(claim => claim.CompanyId == request.CompanyId);
            
            if (!queryable.Any())
                throw new ResourceNotFoundException(ExceptionMessages.CompanyDoesNotExist);

            var results = await _mapper.ProjectTo<ClaimBasicResponseDto>(queryable).ToListAsync(cancellationToken: cancellationToken);
            
            _logger.LogDebug("{Message} {CorrelationId}", LogFmt.Message($"Retrieved list of claims for company identified by {request.CompanyId}"), LogFmt.CorrelationId(request));

            return results;
        }
    }
}