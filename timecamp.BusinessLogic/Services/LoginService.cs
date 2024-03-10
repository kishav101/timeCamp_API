
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using timeCamp.CommonLogic.Dtos;
using timeCamp.CommonLogic.Interfaces;
using timeCamp.Infrastructure;

namespace timecamp.BusinessLogic.Services
{
    public class LoginService : ILoginService
    {
        private ApplicationDbContext _context { get; }

        public LoginService(ApplicationDbContext applicationDbContext) 
        {
            _context = applicationDbContext;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var query = await _context.Employees
                                    .Where(employee => employee.EmployeeCredentials.Username == loginDto.Email)
                                    .FirstOrDefaultAsync();

            var json = JsonConvert.SerializeObject(query);

            return json;
        }

        public Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
