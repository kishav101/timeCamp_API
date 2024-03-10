

using Microsoft.AspNetCore.Mvc;
using timeCamp.CommonLogic.Dtos;

namespace timeCamp.CommonLogic.Interfaces
{
    public interface ILoginService
    {
        Task<string> LoginAsync(LoginDto loginDto);
        Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<string> RegisterUserAsync(RegisterUserDto registerUserDto);
    }
}
