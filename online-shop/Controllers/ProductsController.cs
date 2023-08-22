using Microsoft.AspNetCore.Mvc;
using online_shop.Interfaces;
using online_shop.Models.Product;

namespace online_shop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var products = _productRepository.GetProducts();
        return Ok(products);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        _productRepository.AddProduct(product);
        return Ok(product);
    }
}