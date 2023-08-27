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
        var products = _productRepository.ReadAll();
        return Ok(products);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public IActionResult Get(int id)
    {
        return Ok(_productRepository.Read(id));
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        _productRepository.Create(product);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        _productRepository.Update(id, product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _productRepository.Delete(id);
        return Ok();
    }
}