using CrossCuttingConcerns;
using IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        private CacheTypes _cacheType;
        public void Load(IServiceCollection serviceCollection)
        {
            //does injection for IMemoryCache
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
            if (_cacheType == CacheTypes.MicrosoftMemoryCache)
            {
                serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            }
        }
    }
}
