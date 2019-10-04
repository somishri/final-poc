using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopApp.Domain.Repositories.Interfaces;
using eShopApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        // GET: api/Product
        [HttpGet]
        public List<Payment> GetPayment()
        {
            var payment = _paymentRepository.GetPayments();
            return payment;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetPayment")]
        public Payment GetPayment(int id)
        {
            return _paymentRepository.GetPayment(id);
        }
        // POST: api/Product
        [HttpPost]
        public bool Post([FromBody] Payment payment)
        {

            _paymentRepository.AddPayment(payment);
            return true;
        }

        // GET: api/Payment
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Payment/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Payment
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{


        // PUT: api/Payment/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}