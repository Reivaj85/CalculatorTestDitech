using Calculator.BO.Interfaces;
using Calculator.BO.Supervisor;
using Calculator.DALC.Repositories;
using Calculator.DALC.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Calculator.ApiRest.Configurations {
    public static class ServicesConfiguration {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services) {
            services.AddScoped<IOperationRepository, OperationRepository>();
            return services;
        }

        /// <summary>
        /// Configures the supervisor.
        /// </summary>
        /// <returns>The supervisor.</returns>
        /// <param name="services">Services.</param>
        public static IServiceCollection ConfigureSupervisor(this IServiceCollection services) {
            services.AddScoped<ICalculatorSupervisor, CalculatorSupervisor>();
            return services;
        }

        /// <summary>
        /// Adds the middleware.
        /// </summary>
        /// <returns>The middleware.</returns>
        /// <param name="services">Services.</param>
        public static IServiceCollection AddMiddleware(this IServiceCollection services) {
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
            services.AddCors(options => {
                options.AddPolicy("AllowAll", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .Build());
                    });
    }
}
