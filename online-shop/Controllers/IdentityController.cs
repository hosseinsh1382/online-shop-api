using Microsoft.AspNetCore.Mvc;
using online_shop.Dtos;
using online_shop.Interfaces;

namespace online_shop.Controllers;

[ApiController]
[Route("[action]")]
public class IdentityController : Controller
{
    private readonly IIdentityRepository _identityRepository;

    public IdentityController(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    [HttpPost]
    public IActionResult SignUp(SignUpRequestDto user)
    {
        return Ok(_identityRepository.SignUp(user));
    }

    [HttpPost]
    public IActionResult Login(LoginDto user)
    {
        var result = _identityRepository.Login(user);
        return result != string.Empty ? Ok($"Bearer {result}") : NotFound("User not found");
    }
}