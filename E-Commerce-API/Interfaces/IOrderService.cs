using E_Commerce_API.Entities.Order;
using E_Commerce_API.Identity;

namespace E_Commerce_API.Interfaces
{
    public interface IOrderService
    {

        Task<Order> CreateOrderAsync(int deliveryMethod, string basketId, string buyerEmail, address ShippingAddress);
        Task<IReadOnlyList<Order>> GetUserOrdersAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync();

    }
}
