using online_shop.Dtos;

namespace online_shop.Interfaces;

public interface IIdentityRepository
{
    SignUpResponseDto SignUp(SignUpRequestDto user);

    string Login(LoginDto user);
}