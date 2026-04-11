using System;
using AutoMapper;
using SoftBridge.Shared.Common.Dto.Service;
using SoftBridge.Domain.Models.ServiceAggregates;

namespace SoftBridge.Services.AutoMapper.ServiceProfile;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Service, ServiceDto>();
    }
}
