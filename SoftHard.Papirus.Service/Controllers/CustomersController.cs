using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftHard.Papirus.IServices;
using SoftHard.Papirus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SoftHard.Papirus.Service.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomersService customersService;

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;

        }


        // api/customers

        [HttpGet]
        public IActionResult Get()
        {
            var customers = customersService.Get();
         
            if (this.User.Identity.IsAuthenticated)
            {

            }

            // if (User.HasClaim(c=>c.))

            if (this.User.IsInRole("Administrator"))
            {

            }
          



            return Ok(customers);
        }


        // api/customers/100
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            var customer = customersService.Get(id);

            if (customer==null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
        
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customersService.Add(customer);

            return CreatedAtRoute(new { customer.Id }, customer);
        }
    }
}
