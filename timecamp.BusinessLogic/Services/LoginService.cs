
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using timeCamp.CommonLogic.Dtos;
using timeCamp.CommonLogic.Interfaces;
using timeCamp.CommonLogic.Modal;
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

        public async Task<object?> LoginAsync(LoginDto loginDto)
        {
            var query = await _context.Employees
                                    .Where(employee => employee.EmployeeCredentials.Username == loginDto.Username)
                                    .FirstOrDefaultAsync();

            if (query != null)
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/d3528fc5-f5b3-47a9-a47b-2b006c90e51d/oauth2/v2.0/token");

                var body = new StringBuilder();
                body.Append("client_id=").Append(Environment.GetEnvironmentVariable("Client_Id"));
                body.Append("&scope=").Append(Environment.GetEnvironmentVariable("Scope"));
                body.Append("&client_secret=").Append(Environment.GetEnvironmentVariable("Client_Secret"));
                body.Append("&grant_type=").Append(Environment.GetEnvironmentVariable("Grant_Type"));

                request.Content = new StringContent(body.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            else
            {
                return null;
            }
        }

        public Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> AddClientUserAsync(AddUserDto addUserDto)
        {
            var entity = new Employee()
            {
                Firstname = addUserDto.Firstname,
                Lastname = addUserDto.Lastname,
                Address = addUserDto.Address,
                EmployeeCredentials = new EmployeeCredentials()
                {
                    Username = addUserDto.Username,
                    Password = addUserDto.Password
                }

            };

            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
