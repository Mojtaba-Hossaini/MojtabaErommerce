using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;

    public ProductsController(IGenericRepository<Product> productRepo,
     IGenericRepository<ProductBrand> productBrandRepo,
      IGenericRepository<ProductType> productTypeRepo)
    {
        _productBrandRepo = productBrandRepo;
        _productTypeRepo = productTypeRepo;
        _productRepo = productRepo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _productRepo.ListAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        return await _productRepo.GetByIdAsync(id);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<ProductBrand>> GetProdctBrands()
    {
        return Ok(await _productBrandRepo.ListAllAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<ProductType>> GetProductTypes()
    {
        return Ok(await _productTypeRepo.ListAllAsync());
    }

}
