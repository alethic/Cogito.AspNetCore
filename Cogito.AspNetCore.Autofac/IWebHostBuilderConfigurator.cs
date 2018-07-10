using Microsoft.AspNetCore.Hosting;

namespace Cogito.AspNetCore.Autofac
{

    /// <summary>
    /// Applies additional configuration to a <see cref="IWebHostBuilder"/>.
    /// </summary>
    public interface IWebHostBuilderConfigurator
    {

        /// <summary>
        /// Applies the configuration.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        IWebHostBuilder Apply(IWebHostBuilder builder);

    }

}
