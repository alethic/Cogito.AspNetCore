using Autofac;

using Cogito.Autofac;

namespace Cogito.AspNetCore.Autofac
{

    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
            builder.RegisterType(WebHostLogger.ImplementationType).As(WebHostLogger.InterfaceType);
        }

    }

}
