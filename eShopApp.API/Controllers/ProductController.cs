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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/Product
        [HttpGet]
        public List<Product> Get()
        {
            var products = _productRepository.GetProducts();
            return products;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return _productRepository.GetProduct(id);
        }

        // POST: api/Product
        [HttpPost]
        public bool Post([FromBody] Product product)
        {
           
            _productRepository.AddProduct(product);
            return true;
        }

        // PUT: api/Product/5
        [HttpPut]
        public bool Put([FromBody] Product product)
        {
          _productRepository.UpdateProduct(product);
            return true;
          

          
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}
