namespace E_Commerce_API.Entities.Order
{
    public class DeliveryMethod 
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
