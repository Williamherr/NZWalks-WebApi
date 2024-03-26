using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    // https://localhost:5194/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: https://localhost:5194/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] strings = new string[] { "Student 1", "Student 2", "Student 3" };

            return Ok(strings);
        }
    }
}
