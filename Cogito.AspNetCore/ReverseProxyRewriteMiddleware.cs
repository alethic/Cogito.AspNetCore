using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Cogito.AspNetCore
{

    /// <summary>
    /// Middleware that detects reverse proxies and modifies the ASP.Net context appropriately.
    /// </summary>
    public class ReverseProxyRewriteMiddleware
    {

        readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="next"></param>
        public ReverseProxyRewriteMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Gets the given HTTP header.
        /// </summary>
        /// <param name="http"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        string[] GetHeaderValue(HttpContext http, string name)
        {
            return http.Request.Headers.TryGetValue(name, out var v) ? v.ToArray() : null;
        }

        /// <summary>
        /// Gets the original URL path.
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        string GetOriginalUrl(HttpContext http)
        {
            return GetHeaderValue(http, "X-Original-URL")?.FirstOrDefault();
        }

        /// <summary>
        /// Detects whether we are running behind a reverse proxy and alters the base path appropriately.
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext http)
        {
            if (http == null)
                throw new ArgumentNullException(nameof(http));

            var url = GetOriginalUrl(http);
            if (url != null)
            {
                // extract X-Original-URL headers
                var oUrl = new Uri(url, UriKind.RelativeOrAbsolute);
                var rUrl = (PathString)(oUrl.IsAbsoluteUri ? oUrl.AbsolutePath : url);

                // check that original URL ends with path, thus we know the remaining
                // is our new base
                if (rUrl.EndsWithSegments(http.Request.Path, out var newPathBase))
                {
                    // save away the original path for restoration
                    var path = http.Request.Path;
                    var pathBase = http.Request.PathBase;

                    try
                    {
                        http.Request.Path = path;
                        http.Request.PathBase = newPathBase;
                        await next(http);
                    }
                    finally
                    {
                        http.Request.Path = path;
                        http.Request.PathBase = pathBase;
                    }

                    return;
                }
            }

            await next(http);
        }

    }

    public static class ReverseProxyMiddlewareExtensions
    {

        /// <summary>
        /// Extension method to use <see cref="ReverseProxyRewriteMiddleware"/>.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseReverseProxyMiddleware(this IApplicationBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.UseMiddleware<ReverseProxyRewriteMiddleware>();
        }

    }

}
