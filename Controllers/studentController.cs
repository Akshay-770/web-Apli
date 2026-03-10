using Microsoft.AspNetCore.Mvc;
using WebApi_1.Model;

namespace WebApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<student> students = new List<student>()
        {
            new student() { Id = 1 , Name = "ak" , Age = 22},
            new student() { Id = 2 , Name = "bk" , Age = 25},
            new student() { Id = 3 , Name = "ck" , Age = 18}
        };

        // GET ALL
        [HttpGet]
        public IEnumerable<student> GetStudents()
        {
            return students;
        }

        // GET BY ID
        [HttpGet("{id}")]
        public student GetStudent(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        // POST (Create)
        [HttpPost]
        public void AddStudent(student student)
        {
            students.Add(student);
        }

        // PUT (Update)
        [HttpPut("{id}")]
        public void UpdateStudent(int id, student student)
        {
            var data = students.FirstOrDefault(s => s.Id == id);

            if (data != null)
            {
                data.Name = student.Name;
                data.Age = student.Age;
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            var data = students.FirstOrDefault(s => s.Id == id);

            if (data != null)
            {
                students.Remove(data);
            }
        }
    }
}