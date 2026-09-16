using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestingPlatform.Controllers
{
    public class AnswersController : Controller
    {
        [HttpGet]
        public IActionResult GetAllAnswers()
        {
            return Ok("All students");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAnswersById(int id)
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
        public IActionResult CreateAnswer()
        {
            return Created("/api/students/1", "Student was created");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAnswer(int id)
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
        public IActionResult DeleteAnswer(int id)
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
