using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestingPlatform.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult GetAllTests()
        {
            return Ok("All students");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTestById(int id)
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
        public IActionResult CreateTest()
        {
            return Created("/api/students/1", "Student was created");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateTest(int id)
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
        public IActionResult DeleteTest(int id)
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
