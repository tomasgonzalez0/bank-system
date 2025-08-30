using BankSystem.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace BankSystem.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task SetAsync(string key, object value, TimeSpan expirationTime)
        {
            _memoryCache.Set(key, value, expirationTime);
            await Task.CompletedTask;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            if (_memoryCache.TryGetValue(key, out T value))
            {
                return value;
            }

            return default(T);
        }

        public async Task RemoveAsync(string key)
        {
            _memoryCache.Remove(key);
            await Task.CompletedTask;
        }
    }


}
