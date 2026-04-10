using AutoMapper;
using E_commerce.Shared.Common.Dto.Review;
using E_commerce.Shared.Common.Dto.ServiceRequest;
using SoftBridge.Domain.Models.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftBridge.Services.AutoMapper
{
    public class ServiceRequestProfile: Profile
    {
        public ServiceRequestProfile()
        {
            CreateMap<ServiceRequest, ServiceRequestDto>()
            .ForMember(dest => dest.ServiceTitle,
                       opt => opt.MapFrom(src => src.Service.Title))
            .ForMember(dest => dest.ProviderName,
                       opt => opt.MapFrom(src => src.Provider.User.FullName))
            .ForMember(dest => dest.Status,
                       opt => opt.MapFrom(src => src.Status.ToString()));


            CreateMap<Review, ReviewSummaryDto>();

            CreateMap<Review, ReviewDto>()
            .ForMember(dest => dest.ServiceTitle,
                       opt => opt.MapFrom(src => src.ServiceRequest.Service.Title))
            .ForMember(dest => dest.ProviderName,
                       opt => opt.MapFrom(src => src.Provider.User.FullName));
        }
    }
}
