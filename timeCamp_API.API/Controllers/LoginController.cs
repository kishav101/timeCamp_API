using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using timeCamp.CommonLogic.Dtos;
using timeCamp.CommonLogic.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNet.Identity;
using System.Text;

namespace timeCamp_API.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        private ILoginService _loginService { get; }

        public LoginController(ILoginService loginService) 
        {
            _loginService = loginService;
        }

       
        [HttpPost]
        [Route("/retrieveLogin")]
        public async  Task<IActionResult> RetrieveLogin(LoginDto loginDto)
        {
            var result = await _loginService.LoginAsync(loginDto);

            if(result != null)
            {
                return Ok(result);
            } else
            {
                return NotFound();
            }
          
        }

        [HttpPost]
        [Route("/AddClientUser")]
        public async Task<IActionResult> AddClientUserAsync(AddUserDto addUserDto)
        {
            var result = await _loginService.AddClientUserAsync(addUserDto);
            return Ok(result);
        }
    }
}
