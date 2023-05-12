using E_Commerce_API.Entities;
using E_Commerce_API.Entities.Order;
using E_Commerce_API.Identity;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Specifications;

namespace E_Commerce_API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly IBasketRipository _basketRepo;

        public OrderService(IBasketRipository basketRepo, IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
           _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrderAsync(int deliveryMethod, string basketId, string buyerEmail, address ShippingAddress)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);

            var items = new List<OrderItem>();
            foreach (var item in basket.BaskeItems)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                ProductItemOrder itemOrder = new (productItem.Id, productItem.Name, productItem.PictureUrl);
                OrderItem orderItem = new(itemOrder, productItem.Price,item.Qty);
                items.Add(orderItem);
            }

            var getDeliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethod);

            var subTotal = items.Sum(item => item.Price * item.Qty);

            var order = new Order(buyerEmail,items,ShippingAddress, getDeliveryMethod, subTotal);

            _unitOfWork.Repository<Order>().Add(order);

            var result = await _unitOfWork.Complete();

            await _basketRepo.DeleteBasketAsync(basketId);

            if (result <= 0) return null;

            return order;   
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync()
        {
            
           var allMethods = await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
            return allMethods;
            
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var specification = new OrderWithItemsSpecification(id,buyerEmail);
            return await _unitOfWork.Repository<Order>().GetEntityWithSpecification(specification);

        }

        public async Task<IReadOnlyList<Order>> GetUserOrdersAsync(string buyerEmail)
        {
            var specification = new OrderWithItemsSpecification(buyerEmail);
            return await _unitOfWork.Repository<Order>().ListAsync(specification);
        }
    }
}
