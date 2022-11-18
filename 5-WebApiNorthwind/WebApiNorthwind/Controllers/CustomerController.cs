using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using WebApiNorthwind.Models;
using System.Linq;

namespace WebApiNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly NorthwindContext _context;
        public CustomerController(NorthwindContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable <Customer>Get()
        {
           List <Customer> customers =(from c in _context.Customers
                                       select c).ToList();
            if (customers == null)
            {
                NotFound();
            }

            return customers;
        }


        [HttpGet("{id}")]
        public Customer Get(string id)
        {
            Customer customer = (from c in _context.Customers where c.CustomerId == id select c).SingleOrDefault();
            if (customer == null)
            {
                NotFound();
            }
            return customer;
        }

        [HttpGet("{id}/{companyName}/{contacName}")]
        public dynamic Get(string id, string companyName, string contactName)
        {
            dynamic customers = (from c in _context.Customers
                                 where c.CustomerId == id && c.CompanyName == companyName && c.ContactName == contactName
                                 select new {c.CompanyName, c.ContactName, c.ContactTitle,c.Phone});
            if (id == null)
            {
                NotFound();
            }
            return customers;
        }

        [HttpPost]
        public ActionResult <Customer> Post(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok();
        }

        //[HttpPut]
        //public ActionResult Customer Put(string id, Customer customer)
        //{
        //    if (id != customer.CustomerId)
        //    {
        //        return BadRequest();
        //    }
        //}

    }
}
