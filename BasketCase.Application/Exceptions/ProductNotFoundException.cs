using System.Net;

namespace BasketCase.Application.Exceptions
{
    public class ProductNotFoundException : WarningException
    {
        public ProductNotFoundException(string errorMessage) : base(errorMessage, HttpStatusCode.NotFound)
        {
            ErrorMessage = errorMessage;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}