using System;
using System.Linq;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Cogito.AspNetCore.Autofac
{

    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Registers the Autofac container with the <see cref="IServiceCollection"/>. Not required for ASP.Net Core 3 nor the generic host.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection AddAutofac(this IServiceCollection services, Action<ContainerBuilder> configure = null)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            return AddAutofac(services, () => new AutofacServiceProviderFactory(configure));
        }

        /// <summary>
        /// Registers the Autofac container with the <see cref="IWebHostBuilder"/>. Not required for ASP.Net Core 3 nor the generic host.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="scope"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection AddAutofac(this IServiceCollection services, ILifetimeScope scope, Action<ContainerBuilder> configure = null)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));
            if (scope is null)
                throw new ArgumentNullException(nameof(scope));

            return AddAutofac(services, () => new AutofacChildLifetimeScopeServiceProviderFactory(scope, configure));
        }

        /// <summary>
        /// Adds a custom logger service for the internals of the Web Host.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        static IServiceCollection AddAutofac<TContainerBuilder>(this IServiceCollection services, Func<IServiceProviderFactory<TContainerBuilder>> func)
        {
            var d = services.FirstOrDefault(i => i.ServiceType == typeof(IServiceProviderFactory<IServiceCollection>));
            if (d != null)
                services.Remove(d);

            services.AddSingleton(ctx => func());
            services.AddSingleton<IServiceProviderFactory<IServiceCollection>>(ctx => new AutofacHostingServiceProviderFactory(services => ctx.GetRequiredService<IServiceProviderFactory<TContainerBuilder>>().CreateServiceProvider(ctx.GetRequiredService<IServiceProviderFactory<TContainerBuilder>>().CreateBuilder(services))));
            return services;
        }

        /// <summary>
        /// Provides an implementation of <see cref="IServiceProviderFactory{IServiceCollection}"/> for the Web Host to use internally.
        /// </summary>
        class AutofacHostingServiceProviderFactory : IServiceProviderFactory<IServiceCollection>
        {

            readonly Func<IServiceCollection, IServiceProvider> factory;

            /// <summary>
            /// Initializes a new instances.
            /// </summary>
            /// <param name="factory"></param>
            public AutofacHostingServiceProviderFactory(Func<IServiceCollection, IServiceProvider> factory)
            {
                this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            }

            public IServiceCollection CreateBuilder(IServiceCollection services)
            {
                return services;
            }

            public IServiceProvider CreateServiceProvider(IServiceCollection containerBuilder)
            {
                return factory(containerBuilder);
            }

        }

    }

}
