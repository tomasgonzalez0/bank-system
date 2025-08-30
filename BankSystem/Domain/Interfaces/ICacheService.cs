namespace BankSystem.Domain.Interfaces
{
    public interface ICacheService
    {
        Task SetAsync(string key, object value, TimeSpan expirationTime);
        Task<T> GetAsync<T>(string key);
        Task RemoveAsync(string key);
    }

}
