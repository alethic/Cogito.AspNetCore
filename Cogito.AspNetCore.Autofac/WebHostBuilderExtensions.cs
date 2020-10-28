using System;

using Autofac;

using Microsoft.AspNetCore.Hosting;

namespace Cogito.AspNetCore.Autofac
{

    /// <summary>
    /// Provides extension methods for the <see cref="IWebHostBuilder"/>.
    /// </summary>
    public static class WebHostBuilderExtensions
    {

        /// <summary>
        /// Registers the Autofac container with the <see cref="IWebHostBuilder"/>. Not required for ASP.Net Core 3 nor the generic host.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseAutofac(this IWebHostBuilder builder, Action<ContainerBuilder> configure = null)
        {
            return builder.ConfigureServices(s => s.AddAutofac(configure));
        }

        /// <summary>
        /// Registers the Autofac container with the <see cref="IWebHostBuilder"/>. Not required for ASP.Net Core 3 nor the generic host.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseAutofac(this IWebHostBuilder builder, ILifetimeScope scope, Action<ContainerBuilder> configure = null)
        {
            return builder.ConfigureServices(s => s.AddAutofac(scope, configure));
        }

    }

}
