using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Security
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomJwtGenerator(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddScoped<IJwtGenerator, JwtGenerator>(provider => new JwtGenerator(configuration));
        }
    }
}
