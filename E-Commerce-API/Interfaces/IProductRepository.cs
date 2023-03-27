using E_Commerce_API.Entities;

namespace E_Commerce_API.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetAllProductBrandAsync();
        Task<IReadOnlyList<ProductType>> GetAllProductTypeAsync();

    }
}
