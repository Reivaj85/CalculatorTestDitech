using Calculator.DALC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.ApiRest.Configurations {
    public static class ConfigureConnections {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration) {
            var connection = configuration.GetConnectionString("DefaultConnection") ??
                             "Data Source=CalculatorDitech.db";
            services.AddDbContextPool<CalculatorContext>(options => options.UseSqlite(connection));
            return services;
        }
    }
}
