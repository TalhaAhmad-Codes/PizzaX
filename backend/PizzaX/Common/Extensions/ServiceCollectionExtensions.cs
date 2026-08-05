using FluentValidation;
using MediatR;
using PizzaX.Common.Behaviors;

namespace PizzaX.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register all behaviors and validators with the dependency injection container.
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;
        }
    }
}
