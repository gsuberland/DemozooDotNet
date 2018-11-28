using System;
using System.Collections.Concurrent;
using Xunit.Abstractions;

namespace Polynomial.Demoscene.DemozooApi
{
    public static class ApiCache
    {
        public static ITestOutputHelper Output { get; set; }

        private readonly static ConcurrentDictionary<Tuple<Type, long>, object> _cache = new ConcurrentDictionary<Tuple<Type, long>, object>();
        private readonly static ConcurrentDictionary<Tuple<Type, long>, Lazy<object>> _lazyCache = new ConcurrentDictionary<Tuple<Type, long>, Lazy<object>>();

        public static T Cache<T>(long id, Func<T> lazyGen) where T : class
        {
            var cached = Get<T>(id);

            if (cached != null)
                return cached;

            Add<T>(id, lazyGen);
            return Get<T>(id);
        }

        public static void Add<T>(long id, T obj)
        {
            var key = new Tuple<Type, long>(typeof(T), id);
            _cache[key] = obj;
        }

        public static void Add<T>(long id, Func<T> lazyGen) where T : class
        {
            var key = new Tuple<Type, long>(typeof(T), id);
            _lazyCache[key] = new Lazy<object>(lazyGen);
        }

        public static T Get<T>(long id)
        {
            var key = new Tuple<Type, long>(typeof(T), id);

            if (!_cache.ContainsKey(key) && !_lazyCache.ContainsKey(key))
            {
                Output?.WriteLine("Cache miss on {0}/{1}", typeof(T).Name, id);
            }

            if (_cache.ContainsKey(key))
                return (T)_cache[key];
            if (_lazyCache.ContainsKey(key))
                return (T)_lazyCache[key].Value;

            return default(T);
        }
    }
}
