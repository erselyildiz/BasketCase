using System;
using System.Net;

namespace BasketCase.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ValidationException(string errorMessage)
        {
            ErrorMessage = errorMessage;
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}