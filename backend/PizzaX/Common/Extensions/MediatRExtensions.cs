using PizzaX.Common.Behaviors;

namespace PizzaX.Common.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatRPipeline(
        this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);

                // Behaviors (executed in registration order)
                cfg.AddOpenBehavior(typeof(TrimStringsBehavior<,>));
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
