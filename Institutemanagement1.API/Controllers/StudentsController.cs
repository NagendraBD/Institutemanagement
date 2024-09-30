using Institutemanagement1.API.Data;
using Institutemanagement1.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Institutemanagement1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly InstituteDbContext _dbContext;

        public StudentsController(InstituteDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET : https://localhost:7204/api/students
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _dbContext.Students.ToListAsync();
            return Ok(students);
        }

        // GET : https://localhost:7204/api/students/1
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<IEnumerable<Student>> GetStudent(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            return Ok(student);
        }

        // POST : https://localhost:7204/api/students
        [HttpPost]
        public ActionResult<Student> Create(Student newStudent)
        {
          
            _dbContext.Students.Add(newStudent);
            _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
        }


        [HttpPut]
        public async Task<ActionResult> Update(int id, Student newStudent)
        {
            var student = await _dbContext.Students.FindAsync(id);

            student.Name = newStudent.Name;
            student.Mobile = newStudent.Mobile;
            student.Email = newStudent.Email;
            student.Address = newStudent.Address;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
