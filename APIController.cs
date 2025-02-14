namespace WebApplication1
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class APIController : ControllerBase
    {
        private readonly AuthService _authService;

        public APIController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if (_authService.LoginUser(username, password))
            {
                return Ok("Login successful.");
            }
            return Unauthorized("Invalid credentials.");
        }

        [HttpPost("sanitize")]
        public IActionResult Sanitize(string userInput)
        {
            var sanitizedInput = ValidationHelpers.SanitizeInput(userInput);
            return Ok($"Sanitized Input: {sanitizedInput}");
        }
    }

}
