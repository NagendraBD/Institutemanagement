using Institutemanagement1.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Institutemanagement1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                Name = "Nagendra",
                Mobile = "9980521811",
                Email = "nagendraprasadbd@gmail.com",
                Address = "Bangalore"
            },
            new Student
            {
                Id = 2,
                Name = "Prasad",
                Mobile = "9980521822",
                Email = "prasadbd@gmail.com",
                Address = "Bangalore"
            }
        };

        // GET : https://localhost:7204/api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(students);
        }

        // GET : https://localhost:7204/api/students/1
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<IEnumerable<Student>> GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return Ok(student);
        }

        // POST : https://localhost:7204/api/students
        [HttpPost]
        public ActionResult<Student> Create(Student newStudent)
        {
            newStudent.Id = students.Max(s => s.Id) + 1;
            students.Add(newStudent);
            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
        }





    }
}
