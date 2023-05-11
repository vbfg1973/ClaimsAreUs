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

namespace ClaimsAreUs.Domain.Features.Companies.Queries.CompanyById
{
    /// <summary>
    ///     Handler for CompanyByIdQuery requests
    /// </summary>
    public class CompanyByIdQueryHandler : 
        IRequestHandler<CompanyByIdQuery, CompanyBasicResponseDto>
    {
        private readonly ClaimsAreUsContext _context;
        private readonly ILogger<CompanyByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CompanyByIdQueryHandler(ClaimsAreUsContext context,
            IMapper mapper,
            ILogger<CompanyByIdQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CompanyBasicResponseDto> Handle(CompanyByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("{Message} {CorrelationId}",
                LogFmt.Message($"Attempting to get company identified by {request.CompanyId}"),
                LogFmt.CorrelationId(request));

            var queryable = _context.Companies.Where(x => x.Id == request.CompanyId); 
            
            if (!queryable.Any())
            {
                throw new ResourceNotFoundException(ExceptionMessages.CompanyDoesNotExist);
            }

            var responseDto = await _mapper.ProjectTo<CompanyBasicResponseDto>(queryable).FirstAsync(cancellationToken: cancellationToken);

            _logger.LogDebug("{Message} {CorrelationId}",
                LogFmt.Message($"Retrieved company identified by {request.CompanyId}"), 
                LogFmt.CorrelationId(request));

            return responseDto;
        }
    }
}