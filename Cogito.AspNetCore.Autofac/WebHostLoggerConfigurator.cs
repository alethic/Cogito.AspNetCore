using System;

using Autofac;

using Cogito.Autofac;
using Cogito.Autofac.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

namespace Cogito.AspNetCore.Autofac
{

    [RegisterAs(typeof(IServiceCollectionConfigurator))]
    public class WebHostLoggerConfigurator :
        IServiceCollectionConfigurator
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

        public IServiceCollection Apply(IServiceCollection services)
        {
            services.AddSingleton(WebHostLogger.InterfaceType, ctx => context.Resolve(WebHostLogger.InterfaceType));
            return services;
        }

    }

}
