using System;
using System.Collections.Generic;
using System.Text;

namespace SoftBridge.Domain.Exceptions
{
    public class ClientBadRequestException : BadRequestExceptionCustome
    {
        public ClientBadRequestException(string message, IEnumerable<string>? errors = null) : base(message, errors)
        {
        }
    }
}
