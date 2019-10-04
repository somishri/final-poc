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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _productDbContext;
        public CategoryRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public List<Category> GetCategorys()
        {
            return _productDbContext.Categories.ToList();
        }
        public void AddCategory(Category category)
        {
            try
            {
                _productDbContext.Categories.Add(category);
                _productDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
        public bool UpdateCategory(Category category)
        {
            try
            {
                _productDbContext.Entry(category).State = EntityState.Modified;
                _productDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Category GetCategory(int CatId)
        {
            return _productDbContext.Categories.Find(CatId);
        }

        public bool DeleteCategory(int id)
        {
            Category category = GetCategory(id);
            _productDbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _productDbContext.SaveChanges();
            return true;
        }
        //public bool GetSearch()
        //{
        //  return   _productDbContext.Products.Include(c => c.Category).FirstOrDefault(p => p.CatId);
        //}
    }
}

