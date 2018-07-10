using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Cogito.AspNetCore
{

    public static class WebHostBuilderExtensions
    {

        /// <summary>
        /// Adds in middleware that detects reverse proxies and modifies the ASP.Net context appropriately.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseReverseProxyRewrite(this IWebHostBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));


            // check if UseReverseProxyRewrite was called already
            if (builder.GetSetting(nameof(UseReverseProxyRewrite)) != null)
                return builder;

            builder.UseSetting(nameof(UseReverseProxyRewrite), true.ToString());
            return builder.ConfigureServices(services => services.AddSingleton<IStartupFilter>(new ReverseProxyRewriteSetupFilter()));
        }

        /// <summary>
        /// Builds and runs the web host.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task BuildAndRunAsync(this IWebHostBuilder builder, CancellationToken cancellationToken = default)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.Build().RunAsync(cancellationToken);
        }

    }

}
