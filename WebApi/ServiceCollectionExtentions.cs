using Application.Models;

namespace WebApi
{
    public static class ServiceCollectionExtentions
    {
        // Cache Settings
        public static CacheSettings GetCacheSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var cacheSettingsConfigurations = configuration.GetSection("CacheSettings");
            services.Configure<CacheSettings>(cacheSettingsConfigurations);
            return cacheSettingsConfigurations.Get<CacheSettings>();
        }
    }
}
