using System.Threading.Tasks;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Cogito.AspNetCore.Autofac;
using Cogito.Autofac;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Cogito.AspNetCore.Console
{

    public static class Program
    {

        /// <summary>
        /// Main  application entry point.
        /// </summary>
        /// <param name="args"></param>
        public static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterFromAttributes(typeof(Program).Assembly);
            builder.RegisterAllAssemblyModules();

            using (var container = builder.Build())
            using (var hostScope = container.BeginLifetimeScope())
                await Host.CreateDefaultBuilder(args)
                    .UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(hostScope))
                    .ConfigureWebHost(w => w
                        .UseReverseProxyRewrite()
                        .UseStartup<Startup>()
                        .UseKestrel())
                    .RunConsoleAsync();
        }

    }

}
