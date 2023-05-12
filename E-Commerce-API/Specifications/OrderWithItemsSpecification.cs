using E_Commerce_API.Entities.Order;

namespace E_Commerce_API.Specifications
{
    public class OrderWithItemsSpecification : BaseSpecification<Order>
    {
        public OrderWithItemsSpecification(string email):base(o=>o.BuyerEmail == email)
        {
            AddIncludes(o => o.OrderItems);
            AddIncludes(o => o.DeliveryMethod);
            AddOrderByDesc(o => o.OrderDate);


        }

        public OrderWithItemsSpecification(int id, string email):base(o=>o.Id == id && o.BuyerEmail == email)    
        {
            AddIncludes(o => o.OrderItems);
            AddIncludes(o => o.DeliveryMethod);

        }
    }
}
