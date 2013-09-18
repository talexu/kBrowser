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

        public static TEnum ToEnum<TEnum>(object original) where TEnum : struct
        {
            TEnum resultInputType = default(TEnum);
            if (original != null)
            {
                Enum.TryParse<TEnum>(original.ToString(), true, out resultInputType);
            }
            return resultInputType;
        }

        public static V GetFromIDictionary<K, V>(IDictionary<K, V> dic, K key)
        {
            V value;
            dic.TryGetValue(key, out value);
            return value;
        }

        public static T GetFromIDictionary<K, V, T>(IDictionary<K, V> dic, K key)
        {
            V value = GetFromIDictionary<K, V>(dic, key);
            return ToType<T>(value);
        }

        public static T GetFromIDictionary<T>(IDictionary<string, object> dic, string key)
        {
            return GetFromIDictionary<string, object, T>(dic, key);
        }
    }
}
