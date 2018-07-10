using System;

using Autofac;

using Cogito.Autofac;

using Microsoft.AspNetCore.Hosting;

namespace Cogito.AspNetCore.Autofac
{

    [RegisterAs(typeof(IWebHostBuilderConfigurator))]
    public class WebHostServiceCollectionConfigurator :
        IWebHostBuilderConfigurator
    {

        readonly ILifetimeScope scope;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="scope"></param>
        public WebHostServiceCollectionConfigurator(ILifetimeScope scope)
        {
            this.scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }

        public IWebHostBuilder Apply(IWebHostBuilder builder)
        {
            return builder.ConfigureServices(s => s.Configure(scope));
        }

    }

}
