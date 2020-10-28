using System.Threading.Tasks;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Cogito.AspNetCore.Autofac;
using Cogito.Autofac;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Cogito.AspNetCore.Test.NetCore2
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
                await WebHost.CreateDefaultBuilder(args)
                    .UseAutofac(container)
                    .UseStartup<Startup>()
                    .UseKestrel()
                    .BuildAndRunAsync();
        }

    }

}
