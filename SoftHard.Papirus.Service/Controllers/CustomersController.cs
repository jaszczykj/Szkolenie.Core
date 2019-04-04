using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftHard.Papirus.IServices;
using SoftHard.Papirus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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


            return Ok(customers);
        }


        // api/customers/100
        [HttpGet("{id}")]
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
            customersService.Add(customer);

            return CreatedAtRoute(new { customer.Id }, customer);
        }
    }
}
