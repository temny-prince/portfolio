using Microsoft.AspNetCore.Mvc;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;
using TestingPlatform.Infrastruct.Repositories;

namespace TestingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(AppDbContext appDbContext)
        {
            _repository = new UserRepository(appDbContext);
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var groups = _repository.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetGroupById(int id)
        {
            var group = _repository.GetByIdAsync(id);

            return Ok(group);
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] User user)
        {
            var id = _repository.CreateAsync(user);

            return StatusCode(StatusCodes.Status201Created, new { Id = id });
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateGroup([FromBody] User user)
        {
            _repository.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteGroup(int id)
        {
            _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
