using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestingPlatform.Controllers
{
    public class QuestionsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            return Ok("All students");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetQuestionById(int id)
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
        public IActionResult CreateQuestion()
        {
            return Created("/api/students/1", "Student was created");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateQuestion(int id)
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
        public IActionResult DeleteQuestion(int id)
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
