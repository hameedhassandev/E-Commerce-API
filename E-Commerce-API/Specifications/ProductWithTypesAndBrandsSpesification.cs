using E_Commerce_API.Entities;
using System.Linq.Expressions;

namespace E_Commerce_API.Specifications
{
    public class ProductWithTypesAndBrandsSpesification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpesification()
        {
            AddIncludes(p=>p.ProductType);
            AddIncludes(p=>p.ProductBrand);
        }
        public ProductWithTypesAndBrandsSpesification(int id) :base(x=>x.Id == id)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }
    }
}
