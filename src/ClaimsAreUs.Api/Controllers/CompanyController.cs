using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ClaimsAreUs.Api.Extensions;
using ClaimsAreUs.Domain.Features.Companies.Commands.ClaimUpdate;
using ClaimsAreUs.Domain.Features.Companies.Queries.ClaimsByCompanyId;
using ClaimsAreUs.Domain.Features.Companies.Queries.ClaimsByCompanyIdAndClaimId;
using ClaimsAreUs.Domain.Features.Companies.Queries.CompanyById;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsAreUs.Api.Controllers
{
    /// <summary>
    ///     Companies and their claims
    /// </summary>
    public class CompanyController : BaseV1ApiController
    {
        private readonly IValidator<UpdateClaimCommandDto> _claimUpdateValidator;
        private readonly ILogger<CompanyController> _logger;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        /// <param name="claimUpdateValidator"></param>
        /// <param name="logger"></param>
        public CompanyController(IMediator mediator, IMapper mapper, IValidator<UpdateClaimCommandDto> claimUpdateValidator, ILogger<CompanyController> logger) : base(mediator,
            mapper)
        {
            _claimUpdateValidator = claimUpdateValidator;
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
            var companyByIdQuery = new CompanyByIdQuery
                { CompanyId = companyId, CorrelationId = Request.GetCorrelationId() };

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
            var claimsByCompanyIdQuery = new ClaimsByCompanyIdQuery
                { CompanyId = companyId, CorrelationId = Request.GetCorrelationId() };

            return Ok(await Mediator.Send(claimsByCompanyIdQuery, cancellationToken));
        }

        /// <summary>
        ///     Get specific claim for company identified by its UCR
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="ucr"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{companyId:int}/claims/{ucr}")]
        public async Task<IActionResult> GetSpecificCompanyClaim(int companyId, string ucr,
            CancellationToken cancellationToken)
        {
            var claimsByCompanyIdQuery = new ClaimByCompanyIdAndClaimIdQuery
                { CompanyId = companyId, Ucr = ucr, CorrelationId = Request.GetCorrelationId() };

            return Ok(await Mediator.Send(claimsByCompanyIdQuery, cancellationToken));
        }

        /// <summary>
        ///     Update specific claim identified by its UCR
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="ucr"></param>
        /// <param name="updateClaimCommandDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{companyId:int}/claims/{ucr}")]
        public async Task<IActionResult> UpdateSpecificCompanyClaim(int companyId, string ucr,
            [FromBody] UpdateClaimCommandDto updateClaimCommandDto, CancellationToken cancellationToken)
        {
            var validationResult = await _claimUpdateValidator.ValidateAsync(updateClaimCommandDto, cancellationToken);
            
            if (!validationResult.IsValid) 
            {
                // Add error into ModelState
                validationResult.AddToModelState(ModelState);

                return BadRequest(ModelState);
            }

            var updateClaimCommand = Mapper.Map<UpdateClaimCommandDto, UpdateClaimCommand>(updateClaimCommandDto);
            updateClaimCommand.CompanyId = companyId;
            updateClaimCommand.Ucr = ucr;
            updateClaimCommand.CorrelationId = Request.GetCorrelationId();
            
            return Ok(await Mediator.Send(updateClaimCommand, cancellationToken));
        }
    }
}