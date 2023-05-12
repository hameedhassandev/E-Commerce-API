using E_Commerce_API.Entities.Order;

namespace E_Commerce_API.DTOS
{
    public class OrderReturnDto
    {
        public int Id { get; set; } 
        public string BuyerEmail { get; set; }
        public address shippToAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public IReadOnlyList<OrderItemsDto> OrderItems { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; }

    }
}
