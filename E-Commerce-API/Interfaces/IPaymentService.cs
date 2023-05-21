using E_Commerce_API.Entities;

namespace E_Commerce_API.Interfaces
{
    public interface IPaymentService
    {
        Task<Basket> CreateOrUpdatePayment(string basketId);
    }
}
