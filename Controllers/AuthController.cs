using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _config;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration config)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginDto dto)
    {
        var user = new IdentityUser {UserName = dto.Email, Email = dto.Email};
        var result = await _userManager.CreateAsync(user, dto.Password);

        if(result.Succeeded)
            return Ok("User Created!");



        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
       var user = await _userManager.FindByEmailAsync(dto.Email);
       if(user == null) return Unauthorized();

       var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
       if(!result.Succeeded) return Unauthorized();


       // Generate JWT
            var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return Ok(new {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });



    }




}

public class LoginDto
{
    public string Email {get;set;}
    public string Password { get; set; }
}