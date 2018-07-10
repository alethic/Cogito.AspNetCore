using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Cogito.AspNetCore
{

    /// <summary>
    /// Adds in middleware that detects reverse proxies and modifies the ASP.Net context appropriately.
    /// </summary>
    class ReverseProxyRewriteSetupFilter :
        IStartupFilter
    {

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseReverseProxyMiddleware();
                next(app);
            };
        }

    }

}
