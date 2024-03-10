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
        public async  Task<IActionResult> retrieveLogin(LoginDto loginDto)
        {

            var result = await _loginService.LoginAsync(loginDto);
            return Ok();
        }
    }
}
