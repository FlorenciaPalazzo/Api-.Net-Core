using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private List<Student> students()
        {
            List<Student> studentsLocal = new List<Student>()
            {
                new Student(){Id= 1, LastName="Pint" ,Name= "Gustavo"},
                new Student(){Id= 2, LastName="Mayorga" ,Name= "Maria"},
                new Student(){Id= 3, LastName="Alvarez" ,Name= "Julian"},
            };
            return studentsLocal;
        }
        //GET: /api/student/
        [HttpGet]
        public  IEnumerable<Student> Get()
        {
            return students();
        }

        //GET: /api/student/
        [HttpGet("{id}")]
        public Student Get( int id)
        {
            Student student = students().Find(x => x.Id == id);
            return student;
        }

    }
}
