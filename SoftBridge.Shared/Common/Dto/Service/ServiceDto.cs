using System;

namespace SoftBridge.Shared.Common.Dto.Service;

//Creating the DTO only for service so i can use it in the CategoryftoShowServiceDto ( I didnt start implementing the Service Management Service)
public class ServiceDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DeliveryDays { get; set; }

}
