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
    public IActionResult GetReceipts(int buyerId)
    {
        return Ok(_repository.ReadAllReceipts(buyerId));
    }

    [HttpGet("{receiptId}")]
    public IActionResult GetReceipt(int buyerId, int receiptId)
    {
        var receipt = _repository.ReadReceipt(receiptId);
        if (receipt == null)
            return NotFound();

        return Ok(receipt);
    }
}