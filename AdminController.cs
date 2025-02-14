namespace WebApplication1
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpGet("ManageUsers")]
        public IActionResult ManageUsers()
        {
            return Ok("Only admins can access this.");
        }
    }

}
