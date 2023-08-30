using Microsoft.AspNetCore.Mvc;
using online_shop.Interfaces;
using online_shop.Models;
using online_shop.Models.Account;

namespace online_shop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuyersController : Controller
{
    private IBuyerRepository _repository;

    public BuyersController(IBuyerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.ReadAll());
    }

    [HttpGet("{id}", Name = "GetBuyer")]
    public IActionResult Get(int id)
    {
        var buyer = _repository.Read(id);
        return Ok(buyer);
    }

    [HttpPost]
    public IActionResult Add(Buyer buyer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _repository.Create(buyer);
        return Created($"Get/{buyer.Id}", buyer);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Buyer buyer)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        _repository.Update(id, buyer);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repository.Delete(id);
        return Ok();
    }
}