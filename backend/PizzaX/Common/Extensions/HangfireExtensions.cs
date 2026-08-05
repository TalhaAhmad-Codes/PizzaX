using Hangfire;
using Hangfire.PostgreSql;

namespace PizzaX.Common.Extensions
{
    public static class HangfireExtensions
    {
        public static IServiceCollection AddHangfireServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection"); // Retrieve the database connection string from the configuration settings.

            // Configure Hangfire to use PostgreSQL for storage, specifying the connection string and any necessary options.
            services.AddHangfire(config =>
            {
                config.UsePostgreSqlStorage(options =>
                {
                    options.UseNpgsqlConnection(connectionString);
                });
            });

            // Then, add the Hangfire server to the dependency injection container to enable background job processing.
            services.AddHangfireServer();

            return services;
        }
    }
}
