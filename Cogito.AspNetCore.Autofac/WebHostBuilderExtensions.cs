using System;
using System.Linq;

using Autofac;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Cogito.AspNetCore.Autofac
{

    public static class WebHostBuilderExtensions
    {

        const string CONFIGURED_FLAG = "Cogito.AspNetCore.Autofac:Configured";

        /// <summary>
        /// Configures the <see cref="IWebHostBuilder"/> in accordance with the components framework.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static IWebHostBuilder ConfigureComponents(this IWebHostBuilder builder, ILifetimeScope scope)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (scope == null)
                throw new ArgumentNullException(nameof(scope));

            // prevent double configuration
            if (!bool.TryParse(builder.GetSetting(CONFIGURED_FLAG), out var value) || !value)
            {
                foreach (var i in scope.Resolve<IOrderedEnumerable<IWebHostBuilderConfiguratorProvider>>())
                    foreach (var j in i.GetConfigurators())
                        builder = j.Apply(builder);

                // to prevent double configuration
                builder.UseSetting(CONFIGURED_FLAG, true.ToString());
            }

            return builder;
        }

        /// <summary>
        /// Configures the <see cref="IWebHostBuilder"/> in accordance with the components framework.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static IWebHostBuilder ConfigureComponents<TStartup>(this IWebHostBuilder builder, ILifetimeScope scope)
            where TStartup : class
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (scope == null)
                throw new ArgumentNullException(nameof(scope));

            return builder
                .ConfigureComponents(scope)
                .ConfigureServices(s => s.AddTransient(provider => scope.Resolve<TStartup>()))
                .UseStartup<TStartup>();
        }

    }

}
