using System.Collections.Generic;

namespace Cogito.AspNetCore.Autofac
{

    public interface IWebHostBuilderConfiguratorProvider
    {

        IEnumerable<IWebHostBuilderConfigurator> GetConfigurators();

    }

}
