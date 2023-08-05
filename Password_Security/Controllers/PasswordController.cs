using Microsoft.AspNetCore.Mvc;

namespace Password_Security.Controllers
{
    [ApiController]
    [Route("api")]
    public class PasswordController : ControllerBase
    {
        private readonly PasswordValidator _passwordValidator;

        public PasswordController(PasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }

        [HttpPost("validate-password")]
        public IActionResult ValidatePassword([FromBody] PasswordRequest request)
        {
            if (!_passwordValidator.IsValid(request.Password))
            {
                return Ok(new { IsValid = false });
            }

            return Ok(new { IsValid = true });
        }
    }

    public class PasswordRequest
    {
        public string Password { get; set; }
    }
}