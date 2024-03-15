

using Microsoft.AspNetCore.Mvc;
using timeCamp.CommonLogic.Dtos;

namespace timeCamp.CommonLogic.Interfaces
{
    public interface ILoginService
    {
        Task<object?> LoginAsync(LoginDto loginDto);
        Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<Guid> AddClientUserAsync(AddUserDto addUserDto);
    }
}
