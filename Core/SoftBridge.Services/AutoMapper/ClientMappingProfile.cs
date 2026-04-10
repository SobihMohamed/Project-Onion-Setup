using AutoMapper;
using E_commerce.Shared.Common.Dto.Client;
using E_commerce.Shared.Common.Dto.ServiceRequest;
using SoftBridge.Domain.Models.AccountAggregates;
using SoftBridge.Domain.Models.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftBridge.Services.AutoMapper
{
    public class ClientMappingProfile: Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Client, ClientProfileDto>()
            .ForMember(dest => dest.Name,
                        opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.Email,
                        opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.CreatedAt,
                           opt => opt.MapFrom(src => src.CreatedAt));


            CreateMap<UpdateClientProfileDto, Client>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceRequests, opt => opt.Ignore())
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

            //CreateMap<ServiceRequest, ServiceRequestDto>()
            //    .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Title))
            //    .ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.Service.Provider.User.FullName))
            //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Service.Price))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            //    .ForMember(dest => dest.RequestedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
