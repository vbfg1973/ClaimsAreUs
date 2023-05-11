using AutoMapper;
using MediatR;

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
    }
}