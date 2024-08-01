﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Demo.Models;

namespace WebApi_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student3 : ControllerBase
    {
        static List<Student> list = null;
        public Student3()
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

        public ActionResult<List<Student>> Get()
        {
            if (list.Count == 0)
                return NotFound();
            else 
                return list;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Student> Get(int id)
        { var obj = list.FirstOrDefault(x => x.Id == id);
            if (obj == null) return NotFound();
            else
                return obj;
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            list.Add(student);
            return Created("Rexord has been added", student);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult EditStudent(int id, Student student)
        {
            foreach (Student temp in list)

            {
                if (temp.Id == id)
                {
                    temp.Batch = student.Batch;
                    break;
                }

            }
            return Ok("record has been edited");
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteStduent(int id)
        {
              var obj = list.FirstOrDefault(x => x.Id == id);
            if (obj!=null)
            {
                list.Remove(obj);
            }
            return true;
        }
    }
}