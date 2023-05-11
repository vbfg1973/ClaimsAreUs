using AutoMapper;
using ClaimsAreUs.Common.Abstract;
using ClaimsAreUs.Common.Logging;
using ClaimsAreUs.Data;
using ClaimsAreUs.Data.Models;
using ClaimsAreUs.Domain.Exceptions;
using ClaimsAreUs.Domain.Features.Companies.Responses;
using CustomerManagement.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClaimsAreUs.Domain.Features.Companies.Commands.ClaimUpdate
{
    /// <summary>
    ///     Update a claim
    /// </summary>
    public class UpdateClaimCommand : IRequest<ClaimBasicResponseDto>, ITrackableRequest
    {
        /// <summary>
        ///     Company identifier
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        ///     Claim identifier
        /// </summary>
        public string Ucr { get; set; } = null!;

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
        public string AssuredName { get; set; } = null!;

        /// <summary>
        ///     The amount claimed
        /// </summary>
        public decimal IncurredLoss { get; set; }

        /// <summary>
        ///     Claim now closed?
        /// </summary>
        public bool Closed { get; set; }

        /// <summary>
        ///     Correlation id for tracking the request
        /// </summary>
        public string CorrelationId { get; set; } = null!;
    }

    /// <summary>
    /// Handler for updating claims
    /// </summary>
    public class UpdateClaimCommandHandler : IRequestHandler<UpdateClaimCommand, ClaimBasicResponseDto>
    {
        private readonly ClaimsAreUsContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClaimCommandHandler> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public UpdateClaimCommandHandler(ClaimsAreUsContext context, IMapper mapper,
            ILogger<UpdateClaimCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ClaimBasicResponseDto> Handle(UpdateClaimCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("{Message} {CorrelationId}", LogFmt.Message($"Attempting to update claim identified by {request.Ucr}"), LogFmt.CorrelationId(request));

            await _context.Database.BeginTransactionAsync(cancellationToken);
            
            var queryable = _context.Claims.Where(claim => claim.UCR == request.Ucr && claim.CompanyId == request.CompanyId);
            
            if (!queryable.Any())
                throw new ResourceNotFoundException(ExceptionMessages.ClaimDoesNotExist);

            var claim = await queryable.FirstAsync(cancellationToken);

            _mapper.Map<UpdateClaimCommand, Claim>(request, claim);

            _context.Claims.Update(claim);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            _logger.LogDebug("{Message} {CorrelationId}", LogFmt.Message($"Updated claim identified by {request.Ucr}"), LogFmt.CorrelationId(request));
            
            return _mapper.Map<Claim, ClaimBasicResponseDto>(claim);
        }
    }
}