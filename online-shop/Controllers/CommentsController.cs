using Microsoft.AspNetCore.Mvc;
using online_shop.Dtos;
using online_shop.Interfaces;
using online_shop.Models;

namespace online_shop.Controllers;

[ApiController]
[Route("api/Products/{productId}/[controller]")]
public class CommentsController : Controller
{
    private readonly IProductRepository _repository;

    public CommentsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll(int productId)
    {
        return Ok(_repository.ReadAllComments(productId));
    }

    [HttpGet("{commentId}", Name = "GetComment")]
    public IActionResult Get(int commentId)
    {
        return Ok(_repository.ReadComment(commentId));
    }

    [HttpPost]
    public IActionResult Create(CommentDto commentDto, int productId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var comment = _repository.CreateComment(productId, commentDto);
        return Created(
            $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}/products/{productId}/comments/{comment.Id}",
            comment);
    }

    [HttpPut]
    public IActionResult Put(int commentId, CommentDto comment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _repository.UpdateComment(commentId, comment);
        return Ok();
    }
}