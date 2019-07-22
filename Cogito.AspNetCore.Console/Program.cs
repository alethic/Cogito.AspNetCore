using System.Threading.Tasks;

using Autofac;

using Cogito.AspNetCore.Autofac;
using Cogito.Autofac;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
                await WebHost.CreateDefaultBuilder(args)
                    .UseReverseProxyRewrite()
                    .UseStartup<Startup>(hostScope)
                    .UseKestrel()
                    .BuildAndRunAsync();
        }

    }

}
