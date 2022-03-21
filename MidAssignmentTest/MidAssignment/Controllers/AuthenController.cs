// using Microsoft.VisualBasic;
using MidAssignment.Common;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MidAssignment.Model;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace MidAssignment.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<AuthenController> _logger;

    private string GenerateJwtToken(AuthenRequest model)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Constants.SIGNATURE_KEY);
        var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, model.Username ?? "UNKNOW"),
            new Claim(ClaimTypes.Role, "Administrator")
        };
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = handler.CreateToken(descriptor);
        return handler.WriteToken(token);
    }

    public AuthenController(ILogger<AuthenController> logger)
    {
        _logger = logger;
    }

    [HttpPost("cookie-login")]
    public async Task<IActionResult> CookieLogin(AuthenRequest model)

    {
        if(string.IsNullOrWhiteSpace(model.Username) ||
         string.IsNullOrWhiteSpace(model.Password) ||
         !model.Username.Equals("admin")&&
         !model.Password.Equals("admin"))
         return BadRequest(new { message = "Username or Password is not correct!"});

         var claims = new List<Claim> {
             new Claim(ClaimTypes.Name, model.Username),
             new Claim(ClaimTypes.Role, "Administrator")
         };

         var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

         var properties = new AuthenticationProperties {
             ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
             IsPersistent = true,
         };

         await HttpContext.SignInAsync(
             CookieAuthenticationDefaults.AuthenticationScheme,
             new ClaimsPrincipal(claimsIdentity),
             properties
         );

         return Ok();
        
    }

    [HttpPost("authenticate")]

    public IActionResult Authenticate(AuthenRequest model) {
        if(string.IsNullOrWhiteSpace(model.Username) ||
         string.IsNullOrWhiteSpace(model.Password) ||
         !model.Username.Equals("admin")&&
         !model.Password.Equals("admin"))
         return BadRequest(new { message = "Username or Password is not correct!"});

         var token  = GenerateJwtToken(model);
         return Ok(new {
             Username= model.Username,
             Token = GenerateJwtToken(model)
         });
    }

}

