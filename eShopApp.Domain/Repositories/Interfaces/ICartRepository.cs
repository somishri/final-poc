using eShopApp.Models;
using System.Collections.Generic;

namespace eShopApp.Domain.Repositories.Interfaces
{
    public interface ICartRepository
    {
        bool AddToCart(Cart cart);
        IEnumerable<Cart> getCart(int id);
        bool DeleteCartItem(int id);
    }
}
