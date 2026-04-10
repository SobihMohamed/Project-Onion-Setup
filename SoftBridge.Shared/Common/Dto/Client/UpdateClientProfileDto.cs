using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Shared.Common.Dto.Client
{
    public class UpdateClientProfileDto
    {
        public string FullName { get; set; } = string.Empty;
        public string? ProfileImageUrl { get; set; }
    }
}
