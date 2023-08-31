using Microsoft.AspNetCore.Mvc;
using online_shop.Dtos;
using online_shop.Interfaces;

namespace online_shop.Controllers;

[ApiController]
[Route("api/Products/{productId}/[controller]")]
public class CommentsController : Controller
{
    private readonly ICommentRepository _repository;

    public CommentsController(ICommentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll(int productId)
    {
        return Ok(_repository.ReadAll(productId));
    }

    [HttpGet("{commentId}", Name = "GetComment")]
    public IActionResult Get(int commentId)
    {
        return Ok(_repository.Read(commentId));
    }

    [HttpPost]
    public IActionResult Create(CommentDto commentDto, int productId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var comment = _repository.Create(productId, commentDto);
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

        _repository.Update(commentId, comment);
        return Ok();
    }
}