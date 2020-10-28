using Autofac;

using Cogito.Autofac;

namespace Cogito.AspNetCore.Autofac
{

    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterModule<Cogito.Extensions.Logging.Autofac.AssemblyModule>();
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);

#if !NETCOREAPP3_0
            // ASP.Net Core 2.0's WebHost implementation uses an internal logger type
            builder.RegisterType(WebHostLogger.ImplementationType).As(WebHostLogger.InterfaceType);
#endif
        }

    }

}
