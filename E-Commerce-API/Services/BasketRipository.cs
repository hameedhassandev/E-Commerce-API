using E_Commerce_API.Entities;
using E_Commerce_API.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace E_Commerce_API.Services
{
    public class BasketRipository : IBasketRipository
    {
        private readonly IDatabase _db;
        public BasketRipository(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase(); 
        }
        public async Task<Basket> GetBasketAsync(string basketId)
        {
            var data = await _db.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(data);
        }
        public async Task<Basket> UpdateBasketAsync(Basket basket)
        {
            var isCreated = await _db.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (!isCreated) return null;
            return await GetBasketAsync(basket.Id);
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _db.KeyDeleteAsync(basketId);
        }

    
       
    }
}
