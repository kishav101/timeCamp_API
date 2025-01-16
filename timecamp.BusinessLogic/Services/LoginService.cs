
using Microsoft.EntityFrameworkCore;
using System.Text;
using timeCamp.CommonLogic.Dtos;
using timeCamp.CommonLogic.Interfaces;
using timeCamp.CommonLogic.Modal;
using timeCamp.Infrastructure;

namespace timecamp.BusinessLogic.Services
{
    public class LoginService : ILoginService
    {
        private ApplicationDbContext _context { get; set; }
        private IEmailService _emailService { get; }

        public LoginService(ApplicationDbContext applicationDbContext, IEmailService emailService) 
        {
            _context = applicationDbContext;
            _emailService = emailService;                      
        }

        public async Task<object?> LoginAsync(LoginDto loginDto)
        {
            var query = await _context.Employees.Where(employee => employee.EmployeeCredentials.Username == loginDto.Username && employee.EmployeeCredentials.Password == loginDto.Password 
             && employee.Id.Equals(employee.EmployeeCredentials.EmployeeId)).FirstOrDefaultAsync();

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

        public async Task<string?> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
             var entity = await _context.Employees
                            .Where(exp => exp.EmployeeCredentials.Username == forgotPasswordDto.Username)
                            .Include(employee => employee.EmployeeCredentials)
                            .FirstOrDefaultAsync();

            if (entity != null)
            {
                entity.EmployeeCredentials.Password = forgotPasswordDto.Password;
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<Guid> AddClientUserAsync(AddUserDto addUserDto)
        {
            var entity = new Employee()
            {
                Firstname = addUserDto.Firstname,
                Lastname = addUserDto.Lastname,
                Email = addUserDto.Email,
                IsEmployeeActive = true,
                ProfilePhotoPath= addUserDto.ProfilePhotoPath,
                CreatedAt = addUserDto.CreatedAt,
                ModifiedAt = addUserDto.ModifiedAt,
                RemovedAt = addUserDto.RemovedAt,
                EmployeeCredentials = new EmployeeCredentials()
                {
                    Username = addUserDto.Username,
                    Password = addUserDto.Password,
                    CreatedAt = addUserDto.CreatedAt,
                    ModifiedAt = addUserDto.ModifiedAt,
                    RemovedAt = addUserDto.RemovedAt,
                },
            };

            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public int RegisterClientEmailSend(AddUserDto registerUserDto)
        {
            int result = -1;
            if(registerUserDto.Username != null)
            {
                try
                {
                    _emailService.SendEmail(registerUserDto.Username, "User Registered");
                    result = 0;
                }
                catch (Exception ex)
                {
                    result = -1;
                }
            }

            return result;
        }
    }
}
