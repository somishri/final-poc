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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> GetCat()
        {
            var cat = _categoryRepository.GetCategorys();
            return cat;
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCat")]
        public Category Get(int catid)
        {
            return _categoryRepository.GetCategory(catid);
        }

        // POST: api/Category
        [HttpPost]
        public bool Post([FromBody] Category category)
        {
          _categoryRepository.AddCategory(category);
            return true;
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public bool Put( [FromBody] Category category,[FromRoute] int catid)
        {
            _categoryRepository.UpdateCategory(category);
            return true;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int catid)
        {
           _categoryRepository.DeleteCategory(catid);
            return true;
        }
    }
}
