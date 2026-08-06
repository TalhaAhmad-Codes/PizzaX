using PizzaX.Middlewares;
using Scalar.AspNetCore;

namespace PizzaX.Common.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static WebApplication UseApplicationServices(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
                
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            /* <----- Middlewares -----> */
            app.UseMiddleware<ExceptionMiddleware>();

            /* <----- Auth & Controllers -----> */
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
