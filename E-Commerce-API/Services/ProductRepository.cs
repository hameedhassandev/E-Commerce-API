using E_Commerce_API.Data;
using E_Commerce_API.Entities;
using E_Commerce_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context; 
        }


        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            var allProducts = await _context.Products
                .Include(p=>p.ProductType)
                .Include(p=>p.ProductBrand)
                .ToListAsync();
            return allProducts;
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
           var product = await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p=>p.Id == id);
           return product;  
        }
        public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrandAsync()
        {
            var productBrands = await _context.ProductBrands.ToListAsync();
            return productBrands;
        }

        public async Task<IReadOnlyList<ProductType>> GetAllProductTypeAsync()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return productTypes;
        }


    }
}
