using System;
using System.Collections.Concurrent;
using Xunit.Abstractions;

namespace Polynomial.Demoscene.DemozooApi
{
    public static class ApiCache
    {
        public static ITestOutputHelper Output { get; set; }

        private readonly static ConcurrentDictionary<Tuple<Type, long>, object> _cache = new ConcurrentDictionary<Tuple<Type, long>, object>();

        public static void Add<T>(long id, T obj)
        {
            var key = new Tuple<Type, long>(typeof(T), id);
            _cache[key] = obj;
        }

        public static T Get<T>(long id)
        {
            var key = new Tuple<Type, long>(typeof(T), id);

            if (!_cache.ContainsKey(key))
            {
                Output?.WriteLine("Cache miss on {0}/{1}", typeof(T).Name, id);
            }

            return _cache.ContainsKey(key) ?
                (T)_cache[key] : default(T);
        }
    }
}
