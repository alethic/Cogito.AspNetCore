using System;

using Autofac;

using Cogito.Autofac;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Cogito.AspNetCore.Autofac
{

    [RegisterAs(typeof(IWebHostBuilderConfigurator))]
    public class WebHostLoggerConfigurator :
        IWebHostBuilderConfigurator
    {

        readonly IComponentContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        public WebHostLoggerConfigurator(IComponentContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IWebHostBuilder Apply(IWebHostBuilder builder)
        {
            return builder.ConfigureServices(s =>
            {
#if !NETCOREAPP3_0
                s.AddSingleton(WebHostLogger.InterfaceType, ctx => context.Resolve(WebHostLogger.InterfaceType));
#endif
            });
        }

    }

}
