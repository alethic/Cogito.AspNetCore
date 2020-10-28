using Cogito.Autofac;

using Microsoft.AspNetCore.Builder;

namespace Cogito.AspNetCore.Test.NetCore2
{

    [RegisterAs(typeof(Startup))]
    public partial class Startup
    {

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.Use((ctx, next) => next());
        }

    }

}
