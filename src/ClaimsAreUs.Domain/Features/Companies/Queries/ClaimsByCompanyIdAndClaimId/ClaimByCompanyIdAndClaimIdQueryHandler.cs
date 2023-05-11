using AutoMapper;
using ClaimsAreUs.Common.Logging;
using ClaimsAreUs.Data;
using ClaimsAreUs.Data.Models;
using ClaimsAreUs.Domain.Exceptions;
using ClaimsAreUs.Domain.Features.Companies.Responses;
using CustomerManagement.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClaimsAreUs.Domain.Features.Companies.Queries.ClaimsByCompanyIdAndClaimId
{
    /// <summary>
    ///     Handler for Claims by Company ID
    /// </summary>
    public class ClaimByCompanyIdAndClaimIdQueryHandler : 
        IRequestHandler<ClaimByCompanyIdAndClaimIdQuery, ClaimBasicResponseDto>
    {
        private readonly ClaimsAreUsContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ClaimByCompanyIdAndClaimIdQueryHandler> _logger;

        /// <summary>
        ///     ctor
        /// </summary>
        public ClaimByCompanyIdAndClaimIdQueryHandler(ClaimsAreUsContext context, 
            IMapper mapper, 
            ILogger<ClaimByCompanyIdAndClaimIdQueryHandler> logger)
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
        public async Task<ClaimBasicResponseDto> Handle(ClaimByCompanyIdAndClaimIdQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogDebug("{Message} {CorrelationId}", LogFmt.Message($"Attempting to get claim {request.Ucr} for company identified by {request.CompanyId}"), LogFmt.CorrelationId(request));

            var queryable = _context.Claims.Where(claim => claim.UCR == request.Ucr && claim.CompanyId == request.CompanyId);
            
            if (!queryable.Any())
                throw new ResourceNotFoundException(ExceptionMessages.ClaimDoesNotExist);
            
            var responseDto = await _mapper.ProjectTo<ClaimBasicResponseDto>(queryable).FirstAsync(cancellationToken: cancellationToken);
            
            _logger.LogDebug("{Message} {CorrelationId}", LogFmt.Message($"Retrieved claim {request.Ucr} for company identified by {request.CompanyId}"), LogFmt.CorrelationId(request));

            return responseDto;
        }
    }
}