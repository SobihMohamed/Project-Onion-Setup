using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Shared.Common.Dto.Review
{
    public class AddReviewDto
    {
        public Guid RequestId { get; set; }
        public byte Rating { get; set; }
        public string? Comment { get; set; }
    }
}
