using AutoMapper;
using ClaimsAreUs.Api.Extensions;
using ClaimsAreUs.Domain.Features.Companies.Queries.ClaimsByComapnyId;
using ClaimsAreUs.Domain.Features.Companies.Queries.CompanyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsAreUs.Api.Controllers
{
    /// <summary>
    ///     Companies and their claims
    /// </summary>
    public class CompanyController : BaseV1ApiController
    {
        private readonly ILogger<CompanyController> _logger;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CompanyController(IMediator mediator, IMapper mapper, ILogger<CompanyController> logger) : base(mediator,
            mapper)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Get a company identified by its id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{companyId:int}")]
        public async Task<IActionResult> GetCompany(int companyId, CancellationToken cancellationToken)
        {
            var companyByIdQuery = new CompanyByIdQuery { CompanyId = companyId, CorrelationId = Request.GetCorrelationId() };

            return Ok(await Mediator.Send(companyByIdQuery, cancellationToken));
        }
        
        /// <summary>
        ///     Get list of claims for company identified by its id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{companyId:int}/claims")]
        public async Task<IActionResult> GetCompanyClaims(int companyId, CancellationToken cancellationToken)
        {
            var claimsByCompanyIdQuery = new ClaimsByCompanyIdQuery() { CompanyId = companyId, CorrelationId = Request.GetCorrelationId() };

            return Ok(await Mediator.Send(claimsByCompanyIdQuery, cancellationToken));
        }
    }
}