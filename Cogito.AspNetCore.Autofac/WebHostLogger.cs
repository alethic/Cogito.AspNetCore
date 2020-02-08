using System;

using Microsoft.Extensions.Logging;

namespace Cogito.AspNetCore.Autofac
{

#if !NETCOREAPP3_0

    static class WebHostLogger
    {

        /// <summary>
        /// `ILogger<WebHost>` type.
        /// </summary>
        public static Type InterfaceType => typeof(ILogger<>).MakeGenericType(Type.GetType("Microsoft.AspNetCore.Hosting.Internal.WebHost, Microsoft.AspNetCore.Hosting"));

        /// <summary>
        /// `ILogger<WebHost>` type.
        /// </summary>
        public static Type ImplementationType => typeof(Logger<>).MakeGenericType(Type.GetType("Microsoft.AspNetCore.Hosting.Internal.WebHost, Microsoft.AspNetCore.Hosting"));

    }

#endif

}
