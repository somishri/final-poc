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
        //get: api/cart
        [HttpGet("getcarts/{userId}")]
        public List<Cart> List(int userId)
        {
            return _cartRepository.GetCarts(userId);
        }

        //// GET: api/Cart/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        ////    return "value";
        ////}
        //[HttpGet("{userId}")]
        //public IEnumerable<Cart> List(int userId)
        //{
        //    return _cartRepository.Carts(userId);
        //}
        //[HttpGet("updatequantitytocart/{cartId}/{quantity}")]
        //public void UpdateQuantityToCart([FromRoute] int cartId, [FromRoute] int quantity) //add total amount in cart
        //{
        //    _cartRepository.UpdateQuantityToCart(cartId, quantity);
        //}

        // POST: api/Cart
        [HttpPost]
        public bool Post([FromBody] Cart cart)
        {
            cart.Amount = cart.Price * cart.OrderQuantity;
            return _cartRepository.AddToCart(cart);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _cartRepository.DeleteCart(id);
            return true;
        }

        [HttpDelete("emptycart/{userId}")]
        public bool EmptyCart(int userId)
        {
            _cartRepository.EmptyCart(userId);
            return true;
        }
    }
}
