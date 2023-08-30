using Microsoft.AspNetCore.Mvc;
using online_shop.Interfaces;
using online_shop.Models;

namespace online_shop.Controllers;

[ApiController]
[Route("api/buyers/{buyerId}/[controller]")]
public class ReceiptsController : Controller
{
    private readonly IReceiptRepository _repository;

    public ReceiptsController(IReceiptRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get(int buyerId)
    {
        return Ok(_repository.ReadAllReceipts(buyerId));
    }

    [HttpGet("{receiptId}")]
    public IActionResult Get(int buyerId, int receiptId)
    {
        return Ok(_repository.ReadReceipt(receiptId));
    }
}