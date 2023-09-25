
using Frontend.Models;
using Frontend.Models.Auth;
using Frontend.Models.Posts;

namespace Frontend.Services.Auth
{
    public interface IAuthInterface
    {
        Task<ResponseDto> Register(RegisterRequestDto registerRequestDto);
        Task<LoginResponseDto> Login (LoginRequestDto loginRequestDto);
    }
}