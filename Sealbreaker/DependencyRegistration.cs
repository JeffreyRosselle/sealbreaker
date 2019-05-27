using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Sealbreaker
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddSealbreaker(this IServiceCollection services)
        {
            services.TryAddTransient<ISealBreakerClient, SealBreakerClient>();
            return services;
        }
    }
}
