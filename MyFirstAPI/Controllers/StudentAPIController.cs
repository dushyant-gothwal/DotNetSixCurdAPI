using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MyDbAPIContext context;

        public StudentAPIController(MyDbAPIContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        { 
            var Student = await context.Students.FindAsync(id);
            if (Student == null)
            {
                return NotFound();
            }
            else
            {
                return Student;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        { 
           await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State=EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> StudentDelete(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
