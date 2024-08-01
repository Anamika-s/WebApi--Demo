using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Demo.Models;

namespace WebApi_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> list = null;
        public StudentController()
        {
            if (list == null)
            {
                list = new List<Student>()
                {
                    new Student() { Id = 1, Name = "Deepak", Batch = "DotNet", Doj = Convert.ToDateTime("12/12/2022") },

                    new Student() { Id = 2, Name = "Ajay", Batch = "DotNet", Doj = Convert.ToDateTime("12/12/2022") },
                    new Student() { Id = 3, Name = "Deepak", Batch = "DotNet", Doj = Convert.ToDateTime("12/12/2022") },
                    new Student() { Id = 4, Name = "Deepak", Batch = "DotNet", Doj = Convert.ToDateTime("12/12/2022") },
                    new Student() { Id = 5, Name = "Deepak", Batch = "DotNet", Doj = Convert.ToDateTime("12/12/2022") },
                    new Student() { Id = 6, Name = "Deepak", Batch = "DotNet", Doj = Convert.ToDateTime("12/12/2022") }
                };
            }
        }

        [HttpGet]

        public List<Student> Get()
        {
            return list;
        }

        [HttpGet]
        [Route("{id}")]
        public Student Get(int id)
        {
            return list.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void AddStudent(Student student)
        {
            list.Add(student);
        }

        [HttpPut]
        [Route("{id}")]
        public void EditStudent(int id, Student student)
        {
            foreach (Student temp in list)

            {
                if (temp.Id == id)
                {
                    temp.Batch = student.Batch;
                    break;
                }

            }
        }

        [HttpDelete("{id}")]
        public void DeleteStduent(int id)
        {
              var obj = list.FirstOrDefault(x => x.Id == id);
            if (obj!=null)
            {
                list.Remove(obj);
            }
        }
    }
}