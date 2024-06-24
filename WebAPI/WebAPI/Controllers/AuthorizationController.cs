using BLL;
using BLL.DTO;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly PastaBINContext _pastaBinContext;
        private readonly string _secretKey = "bardzoseketrynykodktorymusibycwtajemnicy";

        public AuthorizationController(PastaBINContext pastaBinContext)
        {
            _pastaBinContext = pastaBinContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest user)
        {
            if (user == null)
            {
                return Unauthorized();
            }

            Cook userX = _pastaBinContext.Cooks.SingleOrDefault(u => u.Login.Equals(user.Login) && u.Password.Equals(user.Password));

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, userX.CookID.ToString()),
                new(ClaimTypes.Name, userX.Login),
            };
            if (userX != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7023", // Adres serwera API
                    audience: "https://localhost:4200", // Adres frontendowego klienta
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
