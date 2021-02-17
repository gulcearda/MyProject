using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
            //servis sağlayıcı fabrikası olarak autofac kullanılır
            //bu yazılır ve sistem addsingletonların yerini işini yapar
            //diğerleri devredışı edilir.
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private class AutofacServiceProviderFactory : IServiceProviderFactory<object>
        {
            public object CreateBuilder(IServiceCollection services)
            {
                throw new NotImplementedException();
            }

            public IServiceProvider CreateServiceProvider(object containerBuilder)
            {
                throw new NotImplementedException();
            }
        }
    }
}
