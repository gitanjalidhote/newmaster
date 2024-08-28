//// Controllers/RegistrationController.cs
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Cryptography.KeyDerivation;
//using System.Security.Cryptography;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;

//[ApiController]
//[Route("api/[controller]")]
//public class RegistrationController : ControllerBase
//{
//    private readonly DbContext _context;

//    public RegistrationController(DbContext context)
//    {
//        _context = context;
//    }

//    [HttpPost]
//    public async Task<IActionResult> Register([FromBody] RegistrationModel model)
//    {
//        // Validate and sanitize user input
//        if (!ModelState.IsValid)
//        {
//            return BadRequest(ModelState);
//        }

//        // Hash and store passwords securely
//        var hashedPassword = HashPassword(model.Password);

//        // Create new user
//        var user = new User
//        {
//            Name = model.Name,
//            Email = model.Email,
//            Password = hashedPassword,
//            Role = model.Role,
//        };

//        _context.Users.Add(user);
//        await _context.SaveChangesAsync();

//        // Generate and return JWT token for successful registration
//        var token = GenerateJwtToken(user);
//        return Ok(new { token });
//    }

//    private string HashPassword(string password)
//    {
//        var salt = new byte[128 / 8];
//        using (var rng = RandomNumberGenerator.Create())
//        {
//            rng.GetBytes(salt);
//        }
//        var hashedPassword = KeyDerivation.Pbkdf2(
//          password: password,
//          salt: salt,
//          prf: KeyDerivationPrf.HMACSHA256,
//          iterationCount: 100000,
//          numBytesRequested: 256 / 8);
//        return Convert.ToBase64String(hashedPassword);
//    }

//    private string GenerateJwtToken(User user)
//    {
//        var claims = new[]
//        {
//      new Claim(ClaimTypes.Name, user.Name),
//      new Claim(ClaimTypes.Email, user.Email),
//      new Claim(ClaimTypes.Role, user.Role),
//    };
//        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"));
//        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//        var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(30), signingCredentials: creds);
//        return new JwtSecurityTokenHandler().WriteToken(token);
//    }
//}

//public class RegistrationModel
//{
//    public string Name { get; set; }
//    public string Email { get; set; }
//    public string Password { get; set; }
//    public string Role { get; set; }
//}




