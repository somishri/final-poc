using eShopApp.Models;
using System.Collections.Generic;

namespace eShopApp.Domain.Repositories.Interfaces
{
    public interface ICartRepository
    {
        bool AddToCart(Cart cart);
        Cart GetCart(int cartId);
        List<Cart> GetCarts(int userId);
        Cart GetCartByProductId(int productId, int userId);
        void UpdateQuantityToCart(int cartId, int quantity);    
        void UpdateCart(Cart cart);
        void DeleteCart(int cartId);
        void EmptyCart(int userId);
    }
}
