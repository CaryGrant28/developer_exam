using Developer_Exam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Developer_Exam.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IAuthService _authService;
        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpGet]
        [Route("token")]
        public async Task<IActionResult> GetToken()
        {
            var authReponse = await _authService.GetToken();

            if (authReponse.Message == "success")
            {
                return Ok(authReponse);
            }
            else
            {
                return BadRequest(authReponse);
            }
        }
    }
}
