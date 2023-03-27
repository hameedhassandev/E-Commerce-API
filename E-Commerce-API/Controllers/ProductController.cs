using E_Commerce_API.Entities;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Services;
using E_Commerce_API.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        public ProductController(IGenericRepository<Product> productRepository
            , IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;   
            _productBrandRepository = productBrandRepository;   
            _productTypeRepository = productTypeRepository; 
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var specification = new ProductWithTypesAndBrandsSpesification();
            var products = await _productRepository.ListAsync(specification);
            return Ok(products);
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null) return NotFound();
            return Ok(product);
        }


        [HttpGet("ProductBrands")]
        public async Task<IActionResult> GetProductBrands()
        {
            var productBrands = await _productBrandRepository.GetAllAsync();
            return Ok(productBrands);
        }


        [HttpGet("ProductTypes")]
        public async Task<IActionResult> GetProductTypes()
        {
            var productTypes = await _productTypeRepository.GetAllAsync();
            return Ok(productTypes);
        }

    }
}
