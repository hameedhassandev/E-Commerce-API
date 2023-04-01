using E_Commerce_API.Entities;
using System.Linq.Expressions;

namespace E_Commerce_API.Specifications
{
    public class ProductWithTypesAndBrandsSpesification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpesification(ProductSpecificationParams ProductParams)
            : base(p=>
                      (string.IsNullOrEmpty(ProductParams.Search) || p.Name.ToLower().Contains(ProductParams.Search)) &&
                      (!ProductParams.BrandId.HasValue || p.ProductTypeId == ProductParams.BrandId) &&
                      (!ProductParams.TypeId.HasValue || p.ProductTypeId == ProductParams.BrandId))
        {
            AddIncludes(p=>p.ProductType);
            AddIncludes(p=>p.ProductBrand);
            AddOrderBy(p=>p.Name);
            ApplayPaging(ProductParams.PageSize * (ProductParams.PageIndex - 1), ProductParams.PageSize);
            if (!string.IsNullOrEmpty(ProductParams.Sort))
            {
                switch (ProductParams.Sort)
                {
                    case "priceAsc":AddOrderBy(p=>p.Price); break;   
                    case "priceDesc":AddOrderByDesc(p=>p.Price); break;
                    default: AddOrderBy(p => p.Name);break;
                }
            }
        }
        public ProductWithTypesAndBrandsSpesification(int id) :base(x=>x.Id == id)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }
    }
}
