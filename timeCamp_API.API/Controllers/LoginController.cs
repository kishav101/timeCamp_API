using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using timeCamp.CommonLogic.Dtos;
using timeCamp.CommonLogic.Interfaces;

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

            if (!result.Equals(""))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        [Route("/ForgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var result = await _loginService.ForgotPasswordAsync(forgotPasswordDto);

            if (result != null)
            {
                return Ok(result);
            }else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("/RegisterClientEmail")]
        public async Task<IActionResult> RegisterClientEmail(AddUserDto registerUserDto)
        {
            try
            {
                _loginService.RegisterClientEmailSend(registerUserDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
