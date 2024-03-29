﻿using AutoMapper;
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
}