using Microsoft.AspNetCore.Mvc;
using online_shop.Interfaces;
using online_shop.Models;

namespace online_shop.Controllers;

[ApiController]
[Route("api/buyers/{buyerId}/Cart")]
public class CartsController : Controller
{
    private readonly ICartRepository _repository;

    public CartsController(ICartRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult AddToCart(CartItem cartItem)
    {
        var cart = _repository.AddToCart(cartItem);
        return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}/buyers/{cartItem.BuyerId}/Cart",cartItem);
    }

    [HttpDelete]
    public IActionResult DeleteAll(int buyerId)
    {
        _repository.DeleteAll(buyerId);
        return Ok();
    }

    [HttpDelete("{cartItemId}")]
    public IActionResult Delete(int cartItemId)
    {
        _repository.Delete(cartItemId);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetCarts(int buyerId)
    {
        return Ok(_repository.ReadAll(buyerId));
    }

    [HttpGet("{cartItemId}")]
    public IActionResult GetCart(int cartItemId)
    {
        var cartItem = _repository.Read(cartItemId);
        if (cartItem==null)
        {
            return NotFound();
        }
        return Ok(cartItem);
    }
}