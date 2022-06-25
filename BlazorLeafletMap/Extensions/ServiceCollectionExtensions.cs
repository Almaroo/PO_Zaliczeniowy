using Microsoft.Extensions.DependencyInjection;

namespace BlazorLeafletMap.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorLeafletMap(this IServiceCollection services)
        {
            services.AddScoped<BlazorLeafletMapModule>();

            return services;
        }
    }
}
