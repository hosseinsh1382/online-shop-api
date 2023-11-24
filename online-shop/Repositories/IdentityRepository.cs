using AutoMapper;
using online_shop.Data;
using online_shop.Dtos;
using online_shop.Interfaces;
using online_shop.Models.Account;

namespace online_shop.Repositories;

public class IdentityRepository : IIdentityRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public IdentityRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public SignUpResponseDto SignUp(SignUpRequestDto user)
    {
        var account = _mapper.Map<Account>(user);
        _dbContext.Accounts.Add(account);
        //_dbContext.SaveChanges();

        return _mapper.Map<SignUpResponseDto>(account);
    }
}