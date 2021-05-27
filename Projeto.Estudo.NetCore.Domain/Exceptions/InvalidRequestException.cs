using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Estudo.NetCore.Domain.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException() { }

        public InvalidRequestException(string message) : base(message) { }

        public InvalidRequestException(string message, Exception innerException) : base(message, innerException) { }

    }
}
