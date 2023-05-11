using AutoMapper;
using ClaimsAreUs.Api.Extensions;
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
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCompany(int id, CancellationToken cancellationToken)
        {
            var companyByIdQuery = new CompanyByIdQuery { CompanyId = id, CorrelationId = Request.GetCorrelationId() };

            return Ok(await Mediator.Send(companyByIdQuery, cancellationToken));
        }
    }
}