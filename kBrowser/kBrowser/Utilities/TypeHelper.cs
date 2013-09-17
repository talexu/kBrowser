using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Utilities
{
    class TypeHelper
    {
        public static T ToType<T>(object original)
        {
            try
            {
                return (T)original;
            }
            catch
            {
                return default(T);
            }
        }
    }
}
