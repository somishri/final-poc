using eShopApp.Domain.Data;
using eShopApp.Domain.Repositories.Interfaces;
using eShopApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShopApp.Domain.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ProductDbContext _productDbContext;
        public CartRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        //*******************************Add to cart*****************************************************************************//
        public bool AddToCart(Cart cart)
        {
            Product product = _productDbContext.Products.Where(x => x.Id == cart.Id).FirstOrDefault();

            if (product.Quantity > cart.quantity)
            {
                var existingCart = GetCartByProductId(cart.Id, cart.CusId);

                if (existingCart == null)
                {
                    cart.Amount = cart.Price * cart.quantity;
                    _productDbContext.Carts.Add(cart);
                    _productDbContext.SaveChanges();
                }
                else
                {
                    existingCart.quantity = existingCart.quantity + cart.quantity;
                    existingCart.Amount = existingCart.quantity * cart.Price;
                    _productDbContext.Entry(existingCart).State = EntityState.Modified;
                    _productDbContext.SaveChanges();
                }
            }
            return true;
        }
        public Cart GetCartByProductId(int productId, int userId)
        {
            return _productDbContext.Carts.SingleOrDefault(c => c.CusId == userId && c.Id == productId);
        }
        public IEnumerable<Cart> getCart(int id)
        {
            var q = from r in _productDbContext.Carts where r.CusId == id select r;
            return q;

        }
        //****************************************************************************************************************//
        public IEnumerable<Cart> GetCarts(int userId)
        {
            return _productDbContext.Carts.Where(c => c.CusId == userId);
        }

        public bool DeleteCartItem(int cartid)
        {
            var delp = _productDbContext.Carts.Where(k => k.CartId == cartid).FirstOrDefault();

            if (delp == null)
            {
                return false;
            }

            _productDbContext.Carts.Remove(delp);
            _productDbContext.SaveChanges();

            return true;
        }


    }
}
