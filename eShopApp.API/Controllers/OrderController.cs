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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        // GET: api/Product
        [HttpGet]
        public List<OrderPlace> GetOrder()
        {
            var Order = _orderRepository.GetOrders();
            return Order;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetOrder")]
        public OrderPlace Get(int id)
        {
            return _orderRepository.GetOrder(id);
        }

        // POST: api/Product
        [HttpPost]
        public bool Post([FromBody] OrderPlace orderPlace)
        {

            _orderRepository.AddOrder(orderPlace);
            return true;
        }

        // PUT: api/Product/5
        [HttpPut]
        public bool Put([FromBody] OrderPlace orderPlace)
        {
            _orderRepository.UpdateOrder(orderPlace);
            return true;



        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }
    }
}