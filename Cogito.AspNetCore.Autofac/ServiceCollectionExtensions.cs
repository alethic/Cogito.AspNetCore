using System;

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
            services.AddSingleton(func());
            return services;
        }

    }

}
