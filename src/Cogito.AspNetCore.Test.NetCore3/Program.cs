using System.Threading.Tasks;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Cogito.Autofac;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Cogito.AspNetCore.Test.NetCore3
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
            builder.RegisterAllAssemblyModules();

            using (var container = builder.Build())
                await Host.CreateDefaultBuilder(args)
                    .UseServiceProviderFactory(ctx => new AutofacChildLifetimeScopeServiceProviderFactory(container, b => b.RegisterAllAssemblyModules()))
                    .ConfigureWebHostDefaults(b => b
                        .UseStartup<Startup>())
                    .RunConsoleAsync();
        }

    }

}
