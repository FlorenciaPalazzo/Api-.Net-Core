using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiEscuela.Data;
using WebApiEscuela.Models;

namespace WebApiEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }

        public AlumnoController(DBEscuelaAPIContext context)
        {
            this.Context = context;
        }


        //TRAER TODOS
        [HttpGet]
        public List<Alumno> Get()
        {
            //EF
            List<Alumno> alumnoList = Context.Alumnos.ToList();
            return alumnoList;

        }

        //TRAER UNO
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            //EF
            Alumno alumno = Context.Alumnos.Find(id);
            return alumno;
        }

        //INSERTAR
        [HttpPost]
        public ActionResult Post(Alumno alumno)
        {
            Context.Alumnos.Add(alumno);
            Context.SaveChanges();
            return Ok();
        }

        //MODIFICAR
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }
             Context.Entry(alumno).State = EntityState.Modified;
             Context.SaveChanges();
             return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            //EF
            var alumno = Context.Alumnos.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            Context.Alumnos.Remove(alumno);
            Context.SaveChanges();
            return alumno;

        }
    }
}
