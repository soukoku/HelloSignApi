using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HelloSignApi
{
    class ThreadSafeDictionary<TKey, TValue>
    {

#if !PORTABLE

        System.Collections.Concurrent.ConcurrentDictionary<TKey, TValue> _dict = new System.Collections.Concurrent.ConcurrentDictionary<TKey, TValue>();

        internal TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            return _dict.GetOrAdd(key, valueFactory);
        }
#else
        Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();
        object _lock = new object();

        internal TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            // a lame implementation
            lock (_lock)
            {
                if (_dict.ContainsKey(key))
                {
                    return _dict[key];
                }
                else
                {
                    var val = valueFactory(key);
                    _dict[key] = val;
                    return val;
                }
            }
        }
#endif

    }
}
