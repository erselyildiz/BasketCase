using System.Net;

namespace BasketCase.Application.Exceptions
{
    public class ProductOutOfStockException : WarningException
    {
        public ProductOutOfStockException(string errorMessage) : base(errorMessage, HttpStatusCode.NotFound)
        {
            ErrorMessage = errorMessage;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}