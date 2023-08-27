using Microsoft.AspNetCore.Mvc;
using online_shop.Interfaces;
using online_shop.Models;

namespace online_shop.Controllers;

[ApiController]
[Route("api/buyers/{buyerId}/[controller]")]
public class ReceiptsController : Controller
{
    private readonly IBuyerRepository _buyerRepository;

    public ReceiptsController(IBuyerRepository buyerRepository)
    {
        _buyerRepository = buyerRepository;
    }

    [HttpGet]
    public IActionResult Get(int buyerId)
    {
        return Ok(_buyerRepository.ReadAllReceipts(buyerId));
    }

    [HttpGet("{receiptId}")]
    public IActionResult Get(int buyerId, int receiptId)
    {
        return Ok(_buyerRepository.ReadReceipt(buyerId, receiptId));
    }

    [HttpPost]
    public IActionResult Post(int buyerId,ICollection<int> productIds)
    {
        var receipt = new Receipt
        {
            Date = DateTime.Now,
            ReceiptCartItems = productIds.Select(productIds => new ReceiptCartItem
            {
                ProductId = productIds
            }).ToList()
        };
        _buyerRepository.CreateReceipt(buyerId,receipt);
        return Ok(receipt);
    }
}