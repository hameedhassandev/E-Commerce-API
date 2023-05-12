using E_Commerce_API.Identity;

namespace E_Commerce_API.Entities.Order
{
    public class Order
    {
        public Order()
        {
                
        }

        public Order(string buyerEmail, IReadOnlyList<OrderItem> orderItems, address shipToAddress,
            DeliveryMethod deliveryMethod, decimal subTotal)
        {
    
            BuyerEmail = buyerEmail;
            OrderItems = orderItems;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            SubTotal = subTotal;

        }
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntendId { get; set; }
        public decimal GetTotal() 
        {
            return SubTotal + DeliveryMethod.Price;
        }
    }
}
