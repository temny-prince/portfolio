using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TestingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok("All students");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentsById (int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id not valid");
            }

            if (id != 1)
            {
                return NotFound("Student not found");
            }
            
            return Ok(id.ToString());
        }

        [HttpPost]
        public IActionResult CreateStudent()
        {
            return Created("/api/students/1", "Student was created");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id not valid");
            }

            if (id != 1)
            {
                return NotFound("Student not found");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")] 
        public IActionResult DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id not valid");
            }

            if (id != 1)
            {
                return NotFound("Student not found");
            }

            return NoContent();
        }
    }
}
