//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace E_Learning.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class Student : ControllerBase
//    {
//        [HttpPost]

//        public async Task<ActionResult<Student>> CreateStudent(Student student)
//        {
//            await context.Student.AddAsync(student);
//            await ContextBoundObject.SaveChangesAsync();
//            return Ok(student);

//        }
//    }
//}


//using E_Learning.Server.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace E_Learning.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : ControllerBase
//    {
//        private readonly ElearningContext _context;

//        public StudentController(ElearningContext context)
//        {
//            _context = context;
//        }

//        [HttpPost]
//        public async Task<ActionResult<Student>> CreateStudent(Student student)
//        {
//            await _context.Student.AddAsync(student);
//            await _context.SaveChangesAsync();
//            return Ok(student);
//        }
//    }
//}


using E_Learning.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Learning.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ElearningContext _context;

        public StudentController(ElearningContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student cannot be null");
                }

                var entity = await _context.Students.AddAsync(student); // Ensure this matches your DbSet property name
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateStudent), new { id = student }, student);
            }
            catch(Exception ex)
            {
                return CreatedAtAction(nameof(CreateStudent), new { id = student }, student);
            }
           
        }
    }
}
