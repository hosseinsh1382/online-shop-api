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
    public IActionResult GetProducts()
    {
        return Ok(_productRepository.ReadAll());
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public IActionResult GetProduct(int id)
    {
        var product = _productRepository.Read(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        _productRepository.Create(product);

        return Created(
            $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}/api/products/{product.Id}",
            product);
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