using Microsoft.AspNetCore.Mvc;
using online_shop.Interfaces;
using online_shop.Models.Account;

namespace online_shop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : Controller
{
    private IAccountRepository _repository;

    public AccountsController(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.ReadAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var buyer = _repository.Read(id);

        if (buyer == null)
            return NotFound();
        return Ok(buyer);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Account buyer)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (_repository.Update(id, buyer))
            return Ok();

        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_repository.Delete(id))
            return Ok();
        return NotFound();
    }
}