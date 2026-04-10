using System;
using AutoMapper;
using E_commerce.Shared.Common.Dto.Service;
using SoftBridge.Domain.Models.ServiceAggregates;

namespace SoftBridge.Services.AutoMapper.ServiceProfile;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Service, ServiceDto>();
    }
}
