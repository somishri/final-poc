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
   public class CustomerRepository:ICustomerRepository
    {
        private readonly ProductDbContext _productDbContext;
        public CustomerRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public List<Customer> GetCustomers()
        {
            return _productDbContext.Customers.ToList();
        }
        public void AddCustomer(Customer customer)
        {
            customer.role = "user";
           
            var FirstName = customer.FirstName;
            var LastName = customer.LastName;
            var Email = customer.Email;
            var PhoneNo = customer.PhoneNumber;
            
            try
            {
                _productDbContext.Customers.Add(customer);
                _productDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                customer.role = "user";
                _productDbContext.Entry(customer).State = EntityState.Modified;
                _productDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Customer GetCustomer(int CusId)
        {
            return _productDbContext.Customers.Find(CusId);
        }

        public bool DeleteCustomer(int id)
        {
            Customer customer = GetCustomer(id);
            _productDbContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _productDbContext.SaveChanges();
            return true;
        }
    }
}

