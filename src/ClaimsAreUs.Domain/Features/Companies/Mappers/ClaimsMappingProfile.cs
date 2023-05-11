using AutoMapper;
using ClaimsAreUs.Common.Extensions;
using ClaimsAreUs.Data.Models;
using ClaimsAreUs.Domain.Features.Companies.Commands.ClaimUpdate;
using ClaimsAreUs.Domain.Features.Companies.Responses;

namespace ClaimsAreUs.Domain.Features.Companies.Mappers
{
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
                    opt => 
                        opt.MapFrom(src => src.ClaimDate.DaysBetweenDates(DateTime.UtcNow)))
                .ForMember(dest => dest.DaysSinceLoss,
                    opt => 
                        opt.MapFrom(src => src.LossDate.DaysBetweenDates(DateTime.UtcNow)));

            CreateMap<UpdateClaimCommandDto, UpdateClaimCommand>();

            CreateMap<UpdateClaimCommand, Claim>()
                .ForMember(dest => dest.UCR, 
                    opt => opt.Ignore()) // Make sure claim identifier is not overwritten
                .ForMember(dest => dest.CompanyId, 
                    opt => opt.Ignore()) // Make sure company identifier is not overwritten
                ;
        }
    }
}