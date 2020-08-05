using System;
using System.Collections.Generic;

namespace Tcoc.OptionType
{
    public static class DictionaryExtensions
    {
        public static Option<TValue> GetOption<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            if(dict == null)
                throw new ArgumentNullException(nameof(dict));

            if(dict.ContainsKey(key))
                return Option.Some(dict[key]);
            else 
                return Option.None<TValue>();
        }
    }
}