using E_Commerce_API.Entities.Order;

namespace E_Commerce_API.DTOS
{
    public class OrderDto
    {
        public string BasketId { get; set; }    
        public int DeleveryMethodId { get; set; }    
        public DeliveryMethod DeleveryMethod { get; set; }
        public AddressDto ShipToAddress { get; set; }    
    }
}
