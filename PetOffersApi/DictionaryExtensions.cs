using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetOffersApi
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue defaultValue = default(TValue))
        {
            return (dic != null && key != null && dic.TryGetValue(key, out TValue value)) ? value : defaultValue;
        }
    }
}
