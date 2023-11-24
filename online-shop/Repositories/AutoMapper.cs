using AutoMapper;
using online_shop.Dtos;
using online_shop.Models.Account;

namespace online_shop.Repositories;

public class AutoMapper :Profile
{
    public AutoMapper()
    {
        CreateMap<Account, SignUpResponseDto>();
        CreateMap<SignUpRequestDto, Account>();
    }
}