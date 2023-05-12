namespace E_Commerce_API.Entities.Order
{
    public class OrderItem
    {

        public OrderItem()
        {

        }

        public OrderItem(ProductItemOrder itemOrder, decimal price, int qty)
        {
            ItemOrder = itemOrder;
            Price = price;
            Qty = qty;
        }
        public int Id { get; set; }
        public ProductItemOrder ItemOrder { get; set; }
        public decimal Price { get; set; } = 0;
        public int Qty { get; set; }
    }
}
