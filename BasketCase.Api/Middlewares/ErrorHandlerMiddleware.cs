using BasketCase.Api.Models;
using BasketCase.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BasketCase.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var baseResponseViewModel = new BaseResponseViewModel();

                switch (error)
                {
                    case WarningException exception:
                        baseResponseViewModel.Error = new ErrorViewModel
                        {
                            StatusCode = exception.StatusCode,
                            Message = exception.ErrorMessage
                        };
                        break;
                    case ValidationException exception:
                        baseResponseViewModel.Error = new ErrorViewModel
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Message = exception.ErrorMessage
                        };
                        break;
                    default:
                        baseResponseViewModel.Error = new ErrorViewModel
                        {
                            Message = "An unexpected error was encountered..",
                            StatusCode = HttpStatusCode.InternalServerError
                        };
                        break;
                }

                response.StatusCode = (int)baseResponseViewModel.Error.StatusCode;

                await response.WriteAsJsonAsync(baseResponseViewModel);
            }
        }
    }}
