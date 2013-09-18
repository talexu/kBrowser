using kBrowser.Initializations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Factories
{
    interface IInitializerFactory
    {
        AbstractInitializer createNonKinectInitializer(IDictionary<string, object> parameters);
    }
}
