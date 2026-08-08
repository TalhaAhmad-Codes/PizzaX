using FluentValidation;
using Microsoft.AspNetCore.Mvc;

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
            context.Response.ContentType = "application/problem+json";

            switch (exception)
            {
                case ValidationException validationException:
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;

                        var errors = validationException.Errors
                            .Select(x => x.ErrorMessage)
                            .ToArray();

                        var problem = new ProblemDetails
                        {
                            Title = "Validation Failed",
                            Status = StatusCodes.Status400BadRequest,
                            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1"
                        };

                        problem.Extensions["errors"] = errors;

                        await context.Response.WriteAsJsonAsync(problem);
                        break;
                    }

                default:
                    {
                        context.Response.StatusCode =
                            StatusCodes.Status500InternalServerError;

                        var problem = new ProblemDetails
                        {
                            Title = "Internal Server Error",
                            Detail = "An unexpected error occurred.",
                            Status = StatusCodes.Status500InternalServerError
                        };

                        await context.Response.WriteAsJsonAsync(problem);
                        break;
                    }
            }
        }
    }
}
