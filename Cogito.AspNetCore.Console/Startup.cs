
using Autofac.Extensions.DependencyInjection;
using Cogito.Autofac;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Cogito.AspNetCore.Console
{

    [RegisterAs(typeof(Startup))]
    public partial class Startup
    {

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            app.Use((ctx, next) => next());
        }

    }

}
