using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsAreUs.Api.Controllers
{
    /// <summary>
    ///     Companies and their claims
    /// </summary>
    public class CompanyController : BaseV1ApiController
    {
        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public CompanyController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}