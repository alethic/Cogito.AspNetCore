using System;

using Autofac;

using Cogito.Autofac.DependencyInjection;

using Microsoft.AspNetCore.Hosting;

namespace Cogito.AspNetCore.Autofac
{

    /// <summary>
    /// Provides extension methods for the <see cref="IWebHostBuilder"/>.
    /// </summary>
    public static class WebHostBuilderExtensions
    {

        /// <summary>
        /// Registers the Autofac container with the <see cref="IWebHostBuilder"/>. Not required for the generic host.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configureAction"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseAutofac(this IWebHostBuilder builder, Action<ContainerBuilder> configureAction = null)
        {
            return builder.ConfigureServices(s => s.AddAutofac(configureAction));
        }

        /// <summary>
        /// Registers the Autofac container with the <see cref="IWebHostBuilder"/>. Not required for the generic host.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="configureAction"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseAutofac(this IWebHostBuilder builder, ILifetimeScope scope, Action<ContainerBuilder> configureAction = null)
        {
            return builder.ConfigureServices(s => s.AddAutofac(scope, configureAction));
        }

    }

}
