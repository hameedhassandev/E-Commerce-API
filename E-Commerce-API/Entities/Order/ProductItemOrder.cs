namespace E_Commerce_API.Entities.Order
{
    public class ProductItemOrder
    {
        public ProductItemOrder()
        {
                
        }
        public int  ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}
