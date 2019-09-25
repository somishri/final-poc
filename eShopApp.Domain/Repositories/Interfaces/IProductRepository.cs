using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        bool UpdateProduct(Product product);
        Product GetProduct(int id);     
        List<Product> GetProducts();
        bool DeleteProduct(int id);
    }
}
