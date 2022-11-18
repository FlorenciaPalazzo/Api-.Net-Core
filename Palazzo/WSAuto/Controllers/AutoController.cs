using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WSAuto.Data;
using WSAuto.Modelos;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WSAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly DBAutoContext _context;
        public AutoController(DBAutoContext context)
        {
            _context = context;
        }
        //Primera Parte
        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            List<Auto> autos = (from a in _context.Autos select a).ToList();
            return autos;
        }

        //TODO

        //[HttpGet("{modelo}")]
        //public List<Auto> Get(string modelo)
        //{
        //    List<Auto> modelos = (from m in _context.Autos where modelo == m.Modelo select m).ToList();
        //    return modelos;
        //}

        [HttpPost]
        public Auto Post(Auto auto)
        {
            _context.Autos.Add(auto);
            _context.SaveChanges();
            return auto;
        }

        //Segunda Parte
        //[HttpGet("{id}")]
        //public Auto Get(int id)
        //{
        //    var auto =(from a in _context.Autos where id==a.Id select a).SingleOrDefault();
        //    return auto;
        //}

        [HttpPut("{id}")]
        public ActionResult Put(int id, Auto auto)
        {
            if (auto.Id != id )
            {
                NotFound();
            }
            _context.Entry(auto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete(int id)
        {
            Auto autoDelete = _context.Autos.Find(id);
            if (autoDelete == null)
            {
                NotFound();
            }
            _context.Remove(autoDelete);
            _context.SaveChanges();
            return autoDelete;
        }

        [HttpGet("{marca}/{modelo}")]
        public IEnumerable<Auto> Get(string marca, string modelo)
        {
            List<Auto> autoMarcaModelo = (from a in _context.Autos where a.Marca == marca && a.Modelo == modelo select a).ToList();
            return autoMarcaModelo;
        }

        [HttpGet("{color}")]
        public List<Auto> Get (string color)
        {
           List <Auto> autoColor = (from c in _context.Autos where c.Color == color select c).ToList();
            return autoColor;
        }

    }
}
