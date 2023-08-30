using Microsoft.AspNetCore.Mvc;
using online_shop.Interfaces;

namespace online_shop.Controllers;

[ApiController]
[Route("api/buyers/{buyerId}/controller")]
public class OrderController : Controller
{
    private readonly IOrderRepository _repository;

    public OrderController(IOrderRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult FinalizeBuy(int buyerId)
    {
        return Ok(_repository.FinalizeBuy(buyerId));
    }
}