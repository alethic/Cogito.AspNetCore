using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Cogito.Autofac;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Cogito.AspNetCore.Console
{

    [RegisterAs(typeof(Startup))]
    public partial class Startup
    {

        readonly ILifetimeScope parent;
        ILifetimeScope scope;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public Startup(ILifetimeScope parent)
        {
            this.parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        /// <summary>
        /// Registers framework dependencies.
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAuthenticationCore();
            return new AutofacServiceProvider(scope = parent.BeginLifetimeScope(builder => builder.Populate(services)));
        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="applicationLifetime"></param>
        public void Configure(IApplicationBuilder app, IApplicationLifetime applicationLifetime)
        {
            app.Use((ctx, next) => next());
            applicationLifetime.ApplicationStopped.Register(() => scope.Dispose());
        }

    }

}
