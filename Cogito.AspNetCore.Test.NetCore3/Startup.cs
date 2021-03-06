﻿using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cogito.AspNetCore.Test.NetCore3
{

    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void ConfigureContainer(AutofacChildLifetimeScopeConfigurationAdapter builder)
        {

        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                var s = ctx.RequestServices.GetRequiredService<ILifetimeScope>();
                var l = ctx.RequestServices.GetRequiredService<ILogger>();
                l.LogInformation("request");
                await next();
            });
        }

    }

}
