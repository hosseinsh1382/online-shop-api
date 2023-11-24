using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using online_shop.Data;
using online_shop.Dtos;
using online_shop.Interfaces;
using online_shop.Models.Account;

namespace online_shop.Repositories;

public class IdentityRepository : IIdentityRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public IdentityRepository(ApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _configuration = configuration;
    }

    public SignUpResponseDto SignUp(SignUpRequestDto user)
    {
        var account = _mapper.Map<Account>(user);
        _dbContext.Accounts.Add(account);
        _dbContext.SaveChanges();

        return _mapper.Map<SignUpResponseDto>(account);
    }

    public string Login(LoginDto user)
    {
        return CheckUserExistence(user) > 0 ? TokenGenerator(CheckUserExistence(user)) : string.Empty;
    }

    private int CheckUserExistence(LoginDto user)
    {
        var result =
            _dbContext.Accounts.SingleOrDefault(a => a.Username == user.Username && a.Password == user.Password);

        return result?.Id ?? 0;
    }

    private string TokenGenerator(int id)
    {
        var user = _dbContext.Accounts.Include(a => a.Roll).FirstOrDefault(a => a.Id == id);
        Console.WriteLine();
        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim("roll",user.Roll.Roll)
        };
        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey") ?? string.Empty)),
                SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}