////using E_Learning.Server.Models;
////using Microsoft.AspNetCore.Http;
////using Microsoft.AspNetCore.Mvc;
////using System.Reflection.Metadata.Ecma335;

////namespace E_Learning.Server.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class Admin : ControllerBase
////    {



////        private readonly ElearningContext _crmSystem;
////        private readonly IConfiguration _configuration;

////        public Admin(ElearningContext crmSystem, IConfiguration configuration)
////        {
////            _crmSystem = crmSystem;
////            _configuration = configuration;
////        }

////        [HttpGet]
////        public ActionResult GetCustomerData()
////        {
////            var data = _crmSystem.Admins.ToList();
////            return Ok(data);
////        }


////        [HttpPost]
////        public ActionResult postCustomerData()
////        {
////            var data = _crmSystem.Admins.ToList();
////            return Ok(data);
////        }

////        //POST APIS......................................................................


////        [HttpPost("register")]
////        public async Task<IActionResult> Register([FromBody] AdminsRegistrationDto registrationDto)

////        {
////            //if (!ModelState.IsValid) {
////            //    return BadRequest(ModelState);
////            //}
////            if (await _crmSystem.Admins.AnyAsync(u => u.Email == registrationDto.Email))
////            {
////                return BadRequest(new { Message = "Email already in use" });
////            }

////            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);

////            var user = new User
////            {
////                Name = registrationDto.Name,
////                Email = registrationDto.Email,
////                PasswordHash = hashedPassword,
////                Role = registrationDto.Role,
////                CreatedAt = DateTime.UtcNow
////            };

////            _crmSystem.Admins.Add(user);
////            await _crmSystem.SaveChangesAsync();

////            return Ok(new { Message = "User registered successfully" });
////        }

////    }
////}


//using BCrypt.Net;
//using E_Learning.Server.Models;
//using Elearning.Server.DTOs;
//using Elearning.Server.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;




//namespace Elearning.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly ElearningDbContext Elearning;
//        private readonly IConfiguration _configuration;

//        public UsersController(ElearningContext Eleaning, IConfiguration configuration)
//        {
//            Elearning = Elearning;
//            _configuration = configuration;
//        }

//        [HttpGet]
//        public ActionResult GetCustomerData()
//        {
//            var data = Elearning.Customers.ToList();
//            return Ok(data);
//        }

//        // POST: api/Student....................
//        [HttpPost]
//        public async Task<IActionResult> CreateUser([FromBody] Student newStudent)
//        {
//            if (newStudent == null)
//            {
//                return BadRequest("User data is null.");
//            }

//            // Optional: Validate user data here
//            if (await Elearning.Users.AnyAsync(u => u.Email == newStudent.Email))
//            {
//                return BadRequest(new { Message = "Email already in use" });
//            }

//            // Hash the password before saving
//            newStudent.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newStudent.PasswordHash);
//            newStudent.CreatedAt = DateTime.UtcNow;

//            Elearning.Users.Add(newStudent);
//            await Elearning.SaveChangesAsync();

//            return Ok(new { Message = "User added successfully", UserId = newStudent.UserId });
//        }


//        // POST: api/Users/register
//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] Admin registration)

//        {
//            //if (!ModelState.IsValid) {
//            //    return BadRequest(ModelState);
//            //}
//            if (await Elearning.Users.AnyAsync(u => u.Email == registration.Email))
//            {
//                return BadRequest(new { Message = "Email already in use" });
//            }

//            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registration.Password);

//            var Student = new Student
//            {
//                Name = registration.Name,
//                Email = registration.Email,
//                PasswordHash = hashedPassword,
//                Role = registration.Role,
//                CreatedAt = DateTime.UtcNow
//            };

//            Elearning.Users.Add(Student);
//            await Elearning.SaveChangesAsync();

//            return Ok(new { Message = "User registered successfully" });
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login(Student loginStudent)
//        {
//            var user = await Elearning.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);
//            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
//            {
//                return Unauthorized(new { Message = "Invalid credentials" });
//            }
//            var token = GenerateJwtToken(user);
//            return Ok(new { Token = token }, user);
//        }


//        // GET: api/Users/{id}
//        [HttpGet("{id}")]
//        [Authorize]
//        public async Task<IActionResult> GetUserById(int id)
//        {
//            var user = await Elearning.Users.FindAsync(id);
//            if (user == null)
//            {
//                return NotFound(new { Message = "User not found" });
//            }

//            var userDto = new
//            {
//                UserId = user.UserId,
//                Name = user.Name,
//                Email = user.Email,
//                Role = user.Role,
//                CreatedAt = user.CreatedAt
//            };

//            return Ok(userDto);
//        }

//        // GET: api/Users/email/{email}
//        [HttpGet("email/{email}")]
//        [Authorize]
//        public async Task<IActionResult> GetUserByEmail(string email)
//        {
//            var user = await Elearning.Users.SingleOrDefaultAsync(u => u.Email == email);
//            if (user == null)
//            {
//                return NotFound(new { Message = "User not found" });
//            }

//            var userDto = new
//            {
//                UserId = user.UserId,
//                Name = user.Name,
//                Email = user.Email,
//                Role = user.Role,
//                CreatedAt = user.CreatedAt
//            };

//            return Ok(user);
//        }
//        private string GenerateJwtToken(Student student)
//        {
//            // Get the Jwt:Key from configuration
//            var key = _configuration["Jwt:Key"];

//            // Handle possible null value
//            if (string.IsNullOrEmpty(key))
//            {
//                throw new ArgumentNullException("Jwt:Key", "The JWT key is not configured.");
//            }

//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            var claims = new[]
//            {
//        new Claim(JwtRegisteredClaimNames.Sub, Student.Email),
//        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//        new Claim(ClaimTypes.Role, user.Role)
//    };

//            var token = new JwtSecurityToken(
//                issuer: _configuration["Jwt:Issuer"],
//                audience: _configuration["Jwt:Issuer"],
//                claims: claims,
//                expires: DateTime.UtcNow.AddMinutes(120),
//                signingCredentials: credentials
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//    }
//}



