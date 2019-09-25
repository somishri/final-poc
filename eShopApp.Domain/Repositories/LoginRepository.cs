using eShopApp.Domain.Data;
using eShopApp.Domain.Repositories.Interfaces;
using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShopApp.Domain.Repositories
{
    public class LoginRepository:IloginRepository
    {
        private readonly ProductDbContext _productDb;
        public LoginRepository(ProductDbContext productDb)
        {
            _productDb = productDb;
        }
        public int Login(LoginViewModel login)
        {
            //try
            //{
                Customer cs = _productDb.Customers.Where(x => x.Email == login.Email && x.Password == login.Password).SingleOrDefault();
                if(cs==null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            //}
            //catch(Exception ex)
            //{
            //    return false;
            //}

        }
    }
}
