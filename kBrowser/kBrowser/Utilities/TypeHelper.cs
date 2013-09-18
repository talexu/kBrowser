using kBrowser.Models.Entity;
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

        public static V GetObjectFromIDictionary<K, V>(IDictionary<K, V> dic, K key)
        {
            V value;
            dic.TryGetValue(key, out value);
            return value;
        }

        public static T GetObjectFromIDictionary<K, V, T>(IDictionary<K, V> dic, K key)
        {
            V value = GetObjectFromIDictionary<K, V>(dic, key);
            return ToType<T>(value);
        }

        public static T GetObjectFromIDictionary<T>(IDictionary<string, object> dic, string key)
        {
            return GetObjectFromIDictionary<string, object, T>(dic, key);
        }

        public static T GetObjectFromIDictionary<T>(object parameters, string key)
        {
            IDictionary<string, object> dic = ToType<IDictionary<string, object>>(parameters);
            return GetObjectFromIDictionary<T>(dic, key);
        }

        public static TEnum GetEnumFromIDictionary<TEnum>(IDictionary<string, object> dic, string key) where TEnum : struct
        {
            object obj_enum = GetObjectFromIDictionary<object>(dic, key);
            return ToEnum<TEnum>(obj_enum);
        }

        public static TEnum GetEnumFromIDictionary<TEnum>(object parameters, string key) where TEnum : struct
        {
            IDictionary<string, object> dic = ToType<IDictionary<string, object>>(parameters);
            return GetEnumFromIDictionary<TEnum>(dic, key);
        }
    }
}
