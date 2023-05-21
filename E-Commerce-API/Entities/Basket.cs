namespace E_Commerce_API.Entities
{
    public class Basket
    {
        public Basket()
        {

        }

        public Basket(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<BaskeItem> BaskeItems { get; set; } = new List<BaskeItem>();
        public int? DeliveryMethodId { get; set; }
        public string PaymentIntent { get; set; }
        public string ClientSecret { get; set; }
    }
} 
