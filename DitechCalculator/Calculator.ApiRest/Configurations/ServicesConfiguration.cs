using Microsoft.Extensions.DependencyInjection;

namespace Calculator.ApiRest.Configurations {
    public static class ServicesConfiguration {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services) {

            return services;
        }
    }
}
