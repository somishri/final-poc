using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopApp.Domain.Data;
using eShopApp.Domain.Repositories.Interfaces;
using eShopApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
            public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository =customerRepository;
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> GetCus()
        {
            var cus = _customerRepository.GetCustomers();
            return cus;
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public Customer Get(int cusid)
        {
            return _customerRepository.GetCustomer(cusid);
        }

        // POST: api/Customer
        [HttpPost]
        public bool Post([FromBody] Customer customer  )
        {
            
            _customerRepository.AddCustomer(customer);
            return true;
           
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
       
        public bool Put([FromBody]Customer customer, [FromRoute] int cusid)
        {
            _customerRepository.UpdateCustomer(customer);
            return true;



        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int cusid)
        {
            _customerRepository.DeleteCustomer(cusid);
            return true;
        }
    }
}
