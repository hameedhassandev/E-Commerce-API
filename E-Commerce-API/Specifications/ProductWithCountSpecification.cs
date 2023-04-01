using E_Commerce_API.Entities;

namespace E_Commerce_API.Specifications
{
    public class ProductWithCountSpecification:BaseSpecification<Product>
    {
        public ProductWithCountSpecification(ProductSpecificationParams productParams)
            :base(p=>
                     (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) &&
                     (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) &&
                     (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId))
        {

        }
    }
}
