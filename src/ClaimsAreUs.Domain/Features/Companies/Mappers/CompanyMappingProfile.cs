using AutoMapper;
using ClaimsAreUs.Common.Extensions;
using ClaimsAreUs.Data.Models;
using ClaimsAreUs.Domain.Features.Companies.Responses;

namespace ClaimsAreUs.Domain.Features.Companies.Mappers
{
    /// <summary>
    ///     Mappers for companies
    /// </summary>
    public class CompanyMappingProfile : Profile
    {
        /// <summary>
        ///     ctor
        /// </summary>
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyBasicResponseDto>();
        }
    }

    /// <summary>
    ///     Mappers for claims
    /// </summary>
    public class ClaimsMappingProfile : Profile
    {
        /// <summary>
        ///     ctor
        /// </summary>
        public ClaimsMappingProfile()
        {
            CreateMap<Claim, ClaimBasicResponseDto>()
                .ForMember(dest => dest.DaysSinceClaim,
                    opt => opt.MapFrom(src => src.ClaimDate.DaysBetweenDates(DateTime.UtcNow)))
                .ForMember(dest => dest.DaysSinceLoss,
                    opt => opt.MapFrom(src => src.LossDate.DaysBetweenDates(DateTime.UtcNow)));
        }
    }
}