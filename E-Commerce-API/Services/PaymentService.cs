using E_Commerce_API.Entities;
using E_Commerce_API.Entities.Order;
using E_Commerce_API.Interfaces;
using Stripe;
using Product = E_Commerce_API.Entities.Product;

namespace E_Commerce_API.Services
{
    public class PaymentService : IPaymentService
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRipository _basketRipository;
        private readonly IConfiguration _configuration;

        public PaymentService(IUnitOfWork unitOfWork, IBasketRipository basketRipository, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _basketRipository = basketRipository;
            _configuration = configuration;
        }

        public async Task<Basket> CreateOrUpdatePayment(string basketId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];
            var basket = await _basketRipository.GetBasketAsync(basketId);

            var shippingPrice = 0m;
            if (basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>()
                    .GetByIdAsync((int)basket.DeliveryMethodId);

                shippingPrice = deliveryMethod.Price;
            }

            foreach(var item in basket.BaskeItems)
            {
                var prodItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                if((decimal)item.Price != prodItem.Price)
                {
                    item.Price = (double)prodItem.Price;
                }
            }

            var service = new PaymentIntentService();
            PaymentIntent intent;
            if (string.IsNullOrEmpty(basket.PaymentIntent))
            {
                var option = new PaymentIntentCreateOptions
                {
                    Amount = (long)basket.BaskeItems.Sum(i => i.Qty * (i.Price * 100))
                        + (long)shippingPrice * 100,

                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }

                };

                intent = await service.CreateAsync(option);
                basket.PaymentIntent = intent.Id;
                basket.ClientSecret = basket.ClientSecret;
            }

            else
            {
                var option = new PaymentIntentUpdateOptions
                {
                    Amount = (long)basket.BaskeItems.Sum(i => i.Qty * (i.Price * 100))
                        + (long)shippingPrice * 100,
                };

                await service.UpdateAsync(basket.PaymentIntent, option);
            }

            await _basketRipository.UpdateBasketAsync(basket);
            return basket;
        }
    }
}
