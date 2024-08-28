using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Homecontroler : ControllerBase
    {
        public List<string> hello = new List<string>()
        {
      "hello",
      "hyy",
      "hiiii"
        };

        [HttpGet]
        public List <string> Gethello()
        {
            return hello;
        }
        [HttpGet("{id}")]
        public string GethellobyIndex(int id)
        {
            return hello.ElementAt(id);

        }
    }
}




 