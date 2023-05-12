namespace E_Commerce_API.DTOS
{
    public class OrderItemsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
