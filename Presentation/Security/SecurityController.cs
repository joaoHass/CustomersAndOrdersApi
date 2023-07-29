using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Authentication;

namespace Presentation.Security
{
    [ApiController]
    [Route("api/v1/security")]
    public class SecurityController : Controller
    {
        private readonly Authentication _auth;

        public SecurityController(Authentication auth)
        {
            _auth = auth;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/generateToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GenerateToken(string username, string password)
        {
            if (username == null || password == null)
                throw new ArgumentNullException();

            if (username == "John" && password == "123")
                return Ok(_auth.GenerateToken());

            return Unauthorized();
        }
    }
}
