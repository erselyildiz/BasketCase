using System.Net;

namespace BasketCase.Application.Exceptions
{
    public class NotTypeOfObjectIdException : WarningException
    {
        public NotTypeOfObjectIdException(string errorMessage) : base(errorMessage, HttpStatusCode.NotFound)
        {
            ErrorMessage = errorMessage;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}