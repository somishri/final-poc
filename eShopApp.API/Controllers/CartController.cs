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
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
    

        [HttpGet("getCartItemByUserID/{id}")]
        public async Task<IActionResult> GetCateItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var cart = _cartRepository.getCart(id);



            if (cart == null)
            {
                return NotFound();
            }



            return Ok(cart);
        }

        //POST: api/Cart
       [HttpPost]
        public bool Post([FromBody] Cart cart)
        {           
            return _cartRepository.AddToCart(cart);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _cartRepository.DeleteCartItem(id);
        }
     
    }
}
