﻿using Autofac;

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

        public void ConfigureContainer(ContainerBuilder builder)
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
                var l = ctx.RequestServices.GetRequiredService<ILogger>();
                l.LogInformation("request");
                await next();
            });
        }

    }

}