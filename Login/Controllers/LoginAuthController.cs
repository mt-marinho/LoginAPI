using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Login.Models;
using Login.Data;

namespace Login.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginAuthController :ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public LoginAuthController(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Models.Login loginModel)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == loginModel.Username);

            if (user == null)
            {
                return Unauthorized("Usuário não encontrado");
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, loginModel.Password);

            if(passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Senha Incorreta");
            }

            return Ok(new { Message = "Login realizado com sucesso!" });
        }
    }
}
