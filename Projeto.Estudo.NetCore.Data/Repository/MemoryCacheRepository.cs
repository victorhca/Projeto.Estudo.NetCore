using Microsoft.Extensions.Caching.Memory;
using Projeto.Estudo.NetCore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.NetCore.Data.Repository
{
    public class MemoryCacheRepository : IMemoryCacheRepository
    {

        private readonly MemoryCache _cache;
        private readonly int _absoluteExpirationInSec;
        private readonly int _slidingExpirationInSec;

        public MemoryCacheRepository(int sizeLimit, int absoluteExpirationInSec, int slidingExpirationInSec)
        {
            _cache = new MemoryCache(new MemoryCacheOptions()
            {
                SizeLimit = sizeLimit
            });
            _absoluteExpirationInSec = absoluteExpirationInSec;
            _slidingExpirationInSec = slidingExpirationInSec;
        }

        public async Task<T> GetOrCreateAsync<T>(string itemId, Func<Task<T>> getItem)
        {
            try
            {
                T item;
                var key = GenerateKey<T>(itemId);
                if (!_cache.TryGetValue<T>(key, out item))
                {
                    item = await getItem();

                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        Size = 1,
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_absoluteExpirationInSec),
                        SlidingExpiration = TimeSpan.FromSeconds(_slidingExpirationInSec)
                    };

                    _cache.Set<T>(key, item, cacheEntryOptions);
                }
                return item;
            }
            catch
            {
                return await getItem();
            }
        }

        public void Clean()
        {
            _cache.Compact(1.0);
        }

        public void Remove<T>(string itemId)
        {
            _cache.Remove(GenerateKey<T>(itemId));
        }
        private string GenerateKey<T>(string itemId) => $"{typeof(T).FullName}:{itemId}";
    }
}
