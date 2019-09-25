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
        public List<Cart> GetCarts(int userId)
        {
            return _productDbContext.Carts.Where(c => c.CusId == userId).ToList();
        }
        public bool AddToCart(Cart cart)
        {
            var existingCart = GetCartByProductId(cart.Id, cart.CusId);
            if (existingCart == null)
            {
                _productDbContext.Carts.Add(cart);
                _productDbContext.SaveChanges();
            }
            else
            {
                existingCart.OrderQuantity = existingCart.OrderQuantity + cart.OrderQuantity;
                existingCart.Amount = existingCart.Price * existingCart.OrderQuantity;
                UpdateCart(existingCart);
            }

            return true;
        }

        public void DeleteCart(int cartId)
        {
            _productDbContext.Carts.Remove(GetCart(cartId));
            _productDbContext.SaveChanges();
        }

        public Cart GetCart(int cartId)
        {
            return _productDbContext.Carts.Find(cartId);
        }

        public void UpdateQuantityToCart(int cartId, int quantity)
        {
            Cart cart = GetCart(cartId);
            cart.OrderQuantity = quantity;
            cart.Amount = cart.Price * cart.OrderQuantity;
            UpdateCart(cart);
        }
        public void UpdateCart(Cart cart)
        {
            _productDbContext.Carts.Update(cart);
            _productDbContext.SaveChanges();
        }

        public Cart GetCartByProductId(int productId, int userId)
        {
            return _productDbContext.Carts.SingleOrDefault(c => c.CusId == userId && c.Id == productId);
        }

        public void EmptyCart(int userId)
        {
            var carts = GetCarts(userId);
            _productDbContext.Carts.RemoveRange(carts);
            _productDbContext.SaveChanges();
        }
    }
}
