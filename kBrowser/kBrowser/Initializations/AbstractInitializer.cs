using kBrowser.Businesses;
using kBrowser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Initializations
{
    abstract class AbstractInitializer
    {
        private AbstractInitializer _s;
        protected IDictionary<string, object> _parameters;

        public AbstractInitializer(IDictionary<string, object> parameters)
        {
            _parameters = parameters;
            _s = TypeHelper.GetFromIDictionary<string, object, AbstractInitializer>(_parameters, Config.k_decoratedInitializer);
        }

        public virtual void run()
        {
            if (_s != null)
            {
                _s.run();
            }
        }
    }
}
