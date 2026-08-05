using PizzaX.Features.Identity.Users.Providers;
using PizzaX.Features.Identity.Users.Providers.Interfaces;

namespace PizzaX.Common.Extensions
{
    public static class ProviderExtensions
    {
        public static IServiceCollection AddProviders(
            this IServiceCollection services)
        {
            /* <----- Identity -----> */
            services.AddScoped<IUserProvider, UserProvider>();

            return services;
        }
    }
}
