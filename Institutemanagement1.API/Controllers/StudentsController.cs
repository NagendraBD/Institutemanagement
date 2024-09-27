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

        // https://localhost:7204/api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(students);
        }

        // https://localhost:7204/api/students/1
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<IEnumerable<Student>> GetStudent()
        {
            var student = students.FirstOrDefault(s => s.Id == 1);
            return Ok(student);
        }





    }
}
