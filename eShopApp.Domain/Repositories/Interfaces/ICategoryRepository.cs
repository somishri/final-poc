using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.Domain.Repositories.Interfaces
{
    
        public interface ICategoryRepository       {
            void AddCategory(Category category);
            bool UpdateCategory(Category category);
           Category GetCategory(int catid);
            List<Category> GetCategorys();
            bool DeleteCategory(int catid);
        }
    }

