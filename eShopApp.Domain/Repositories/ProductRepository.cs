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
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productContext;
        public ProductRepository(ProductDbContext productContext)
        {
            _productContext = productContext;
        }
        public List<Product> GetProducts()
        {
            return _productContext.Products.ToList();
        }
        public void AddProduct(Product product)
        {
            try
            {
                _productContext.Products.Add(product);
                _productContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
        public bool UpdateProduct(Product product)
        {
           // try
            //{
                _productContext.Entry(product).State = EntityState.Modified;
                _productContext.SaveChanges();
                return true;
            //}
            //catch
            //{
            //    return false;
            //}

        }

        public Product GetProduct(int id)
        {
            return _productContext.Products.Find(id);
        }

        public bool DeleteProduct(int id)
        {
            Product product = GetProduct(id);
            _productContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _productContext.SaveChanges();
            return true;
        }
    }
}

