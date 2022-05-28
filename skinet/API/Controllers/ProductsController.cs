using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> productsRepo;
        private readonly IGenericRepository<ProductType> productTypesRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;

        public ProductsController(IGenericRepository<Product> _products, IGenericRepository<ProductType> _productTypes, IGenericRepository<ProductBrand> _productBrand)
        {
            productsRepo = _products;
            productTypesRepo = _productTypes;
            productBrandRepo = _productBrand;
        }
       [HttpGet]
       public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductsTypeBrandSpec();
            var products = await productsRepo.ListAsync(spec);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsTypeBrandSpec(id);

            return await productsRepo.GetEntityWithSpec(spec);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await productTypesRepo.ListAllAsync());
        }
    }
}
