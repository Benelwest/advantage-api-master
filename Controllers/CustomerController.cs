using Advantage.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Advantage.API.Models
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ApiContext _ctx;

        public CustomerController(ApiContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public ActionResult Get(int pageIndex, int pageSize)
        {
            var data = _ctx.Customer.OrderBy( c => c.Id);
            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public ActionResult GetCustomer(int id)
        {
            var customer = _ctx.Customer.Find(id);
            return Ok(customer);
        }

         [HttpPost]
         public IActionResult Post([FromBody] Customer customer)
         {
             if(customer == null)
             {
                 return BadRequest();
             }
             _ctx.Customer.Add(customer);
             _ctx.SaveChanges();

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);

         }

    }

}