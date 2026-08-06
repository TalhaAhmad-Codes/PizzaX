using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace PizzaX.Middlewares
{
    public sealed class ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType = "application/json";

            ProblemDetails problem;

            switch (exception)
            {
                case ValidationException validationException:

                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    problem = new ValidationProblemDetails(
                        validationException.Errors
                            .GroupBy(x => x.PropertyName)
                            .ToDictionary(
                                g => g.Key,
                                g => g.Select(x => x.ErrorMessage).ToArray()))
                    {
                        Title = "Validation Failed",
                        Status = StatusCodes.Status400BadRequest,
                        Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1"
                    };

                    break;

                default:

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    problem = new ProblemDetails
                    {
                        Title = "Internal Server Error",
                        //Detail = "An unexpected error occurred.",
                        Detail = exception.Message,
                        Status = StatusCodes.Status500InternalServerError
                    };

                    break;
            }

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(problem));
        }
    }
}
