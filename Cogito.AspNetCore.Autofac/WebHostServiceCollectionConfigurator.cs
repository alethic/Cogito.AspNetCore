using System;

using Autofac;

using Cogito.Autofac;
using Cogito.Autofac.DependencyInjection;

using Microsoft.AspNetCore.Hosting;

namespace Cogito.AspNetCore.Autofac
{

    [RegisterAs(typeof(IWebHostBuilderConfigurator))]
    public class WebHostServiceCollectionConfigurator :
        IWebHostBuilderConfigurator
    {

        readonly IComponentContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        public WebHostServiceCollectionConfigurator(IComponentContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IWebHostBuilder Apply(IWebHostBuilder builder)
        {
            return builder.ConfigureServices(s => s.Configure(context.Resolve<ILifetimeScope>()));
        }

    }

}
