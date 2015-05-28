using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    // This is primarily intended to make working with (and initializing) enumerable sequences of KeyValuePairs easier
    public class KeyValueList<TKey, TValue> : List<KeyValuePair<TKey, TValue>>
    {
        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }
    }

    public class StringKeyValueList : List<KeyValuePair<string, string>>
    {
        public void Add(string key, string value)
        {
            Add(new KeyValuePair<string, string>(key, value));
        }
    }

    public class ObjectKeyValueList : List<KeyValuePair<string, object>>
    {
        public void Add(string key, object value)
        {
            Add(new KeyValuePair<string, object>(key, value));
        }
    }
}
