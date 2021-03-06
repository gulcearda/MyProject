using System;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            //ICacheManaegr da bunun sayesinde çalışıyor Redis e geçmek için
            //yapılacak tek şey Memory Silip Redis yazmak.
            serviceCollection.AddMemoryCache();
            //IMemoryCache in karşılığı budur bunun sayesinde çalışıyor
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
