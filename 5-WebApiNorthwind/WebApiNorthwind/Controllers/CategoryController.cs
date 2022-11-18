using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebApiNorthwind.Models;
using System.Linq;

namespace WebApiNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly NorthwindContext _context;
        public CategoryController(NorthwindContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            List<Category> categorias = (from c in _context.Categories select c).ToList();
            return categorias;
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            Category categoryId = _context.Categories.Find(id);
            if (categoryId== null)
            {
                NotFound();
        }
            return categoryId;
    }
}
}
