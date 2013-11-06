using kBrowser.Businesses;
using kBrowser.Initializations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Factories
{
    class InitializerFactory : IInitializerFactory
    {
        public AbstractInitializer createNonKinectInitializer(IDictionary<string, object> parameters)
        {
            AbstractInitializer initializer = new DataInitializer(parameters);
            return initializer;
        }

        public AbstractInitializer createInitializer(IDictionary<string, object> parameters)
        {
            AbstractInitializer initializer = new DataInitializer(parameters);

            return initializer;
        }
    }
}
