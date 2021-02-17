using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        //bu ne işe yarar?
        //startupta yazdıklarımızı, uygulamamıza yardımcı olur burası

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            //bu startuptali addsingleton iproductserviceli kısımdır.
            //single instance tek bir instance oluşturur.

            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            //bunlar bir daha newlemimize engel oluyor böylece bir daha newlemiyoruz. constructor deyip geçicez.

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
