using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kBrowser.Models.Entity
{
    class SoDictionary : Dictionary<string, object>
    {
        public SoDictionary()
            : base()
        {
        }

        public SoDictionary(string k, object v)
            : base()
        {
            Add(k, v);
        }

        public SoDictionary(string k1, object v1, string k2, object v2)
            : base()
        {
            this.Add(k1, v1);
            Add(k2, v2);
        }

        public SoDictionary(Array kvs)
            : base()
        {
            for (int i = 0; i < kvs.Length; i++)
            {
                try
                {
                    Add(kvs.GetValue(i).ToString(), kvs.GetValue(++i));
                }
                catch
                {
                }
            }
        }
    }
}
