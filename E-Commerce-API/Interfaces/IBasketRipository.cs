using E_Commerce_API.Entities;

namespace E_Commerce_API.Interfaces
{
    public interface IBasketRipository
    {
        Task<Basket> GetBasketAsync(string basketId);
        Task<Basket> UpdateBasketAsync(Basket baskt);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
