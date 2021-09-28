using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using SimpleSite.App_Start;
using SimpleSite.Entities.Contracts;
using SimpleSite.Entities.Repository;
using SimpleSite.Models;
using SimpleSite.Services;

namespace SimpleSite.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new Autofac.ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterWebApiModelBinderProvider();


            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<OrderProductService>().As<IOrderProductService>();

            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderProductRepository>().As<IOrderProductRepository>();

            builder.RegisterType<Models.AppContext>();

            builder.RegisterType<DataManager>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = configuration.CreateMapper();

            builder.RegisterInstance(mapper);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}