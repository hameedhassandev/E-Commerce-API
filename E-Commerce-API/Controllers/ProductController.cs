using AutoMapper;
using E_Commerce_API.DTOS;
using E_Commerce_API.Entities;
using E_Commerce_API.Helpers;
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
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository
            , IGenericRepository<ProductBrand> productBrandRepository, 
            IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productRepository = productRepository;   
            _productBrandRepository = productBrandRepository;   
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery]ProductSpecificationParams ProductParams)
        {
            var specification = new ProductWithTypesAndBrandsSpesification(ProductParams);
            var countSpecification = new ProductWithCountSpecification(ProductParams);
            var totalItems = await _productRepository.CountAsync(countSpecification);
            var products = await _productRepository.ListAsync(specification);
            var results = _mapper.Map<IReadOnlyList<ProductDto>>(products);
            return Ok(new Pagination<ProductDto>(ProductParams.PageIndex,ProductParams.PageSize,totalItems,results));
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var specification = new ProductWithTypesAndBrandsSpesification(id);
            var product = await _productRepository.GetEntityWithSpecification(specification);
            if(product == null) return NotFound();
            var result = _mapper.Map<ProductDto>(product);
            return Ok(result);
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
