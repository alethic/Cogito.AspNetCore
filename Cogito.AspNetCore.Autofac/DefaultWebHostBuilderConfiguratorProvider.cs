using System;
using System.Collections.Generic;

using Cogito.Autofac;

namespace Cogito.AspNetCore.Autofac
{

    [RegisterAs(typeof(IWebHostBuilderConfiguratorProvider))]
    [RegisterOrder(0)]
    public class DefaultWebHostBuilderConfiguratorProvider :
        IWebHostBuilderConfiguratorProvider
    {

        readonly IEnumerable<IWebHostBuilderConfigurator> configurators;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configurators"></param>
        public DefaultWebHostBuilderConfiguratorProvider(IEnumerable<IWebHostBuilderConfigurator> configurators)
        {
            this.configurators = configurators ?? throw new ArgumentNullException(nameof(configurators));
        }

        /// <summary>
        /// Gets the configurations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IWebHostBuilderConfigurator> GetConfigurators()
        {
            return configurators;
        }

    }

}
