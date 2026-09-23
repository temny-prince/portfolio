using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Data;
using TestingPlatform.Models;

namespace TestingPlatform.Controllers
{

    [ApiController]
    [Route("api/[controller]")] 
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public GroupsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var groups = _db.Groups
                .Include(g => g.Direction)
                .Include(g => g.Course)
                .Include(g => g.Project)
                .Include(g => g.Students)
                    .ThenInclude(s => s.User)
                .ToList();

            return Ok(groups); 
        }

        [HttpGet("{id:int}")]
        public IActionResult GetGroupById(int id)
        {
            if (id <= 0)
                return BadRequest("Некорректный id"); 

            var group = _db.Groups
                .Include(g => g.Direction)
                .Include(g => g.Course)
                .Include(g => g.Project)
                .Include(g => g.Students)
                    .ThenInclude(s => s.User)
                .FirstOrDefault(g => g.Id == id);

            if (group is null)
                return NotFound(); 

            return Ok(group); 
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] Group group)
        {
            var nameExists = _db.Groups.Any(g => g.Name == group.Name);
            if (nameExists)
                return Conflict("Группа с таким названием уже существует"); 

            if (!_db.Directions.Any(d => d.Id == group.DirectionId))
                return BadRequest("Указанное направление не найдено");

            if (!_db.Courses.Any(c => c.Id == group.CourseId))
                return BadRequest("Указанный курс не найден");

            if (!_db.Projects.Any(p => p.Id == group.ProjectId))
                return BadRequest("Указанный проект не найден");

            _db.Groups.Add(group);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, group);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateGroup(int id, [FromBody] Group group)
        {
            if (id != group.Id)
                return BadRequest("Id в URL и в теле запроса не совпадают");

            var exists = _db.Groups.FirstOrDefault(g => g.Id == id);
            if (exists == default)
                return NotFound();

            var nameInUse = _db.Groups.Any(g => g.Name == group.Name && g.Id != id);
            if (nameInUse)
                return Conflict("Группа с таким названием уже существует"); // 409

            _db.Entry(group).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteGroup(int id)
        {
            var group = _db.Groups.Find(id);
            if (group is null)
                return NotFound();

            _db.Groups.Remove(group);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
