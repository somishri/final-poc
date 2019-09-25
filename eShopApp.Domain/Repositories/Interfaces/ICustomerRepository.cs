using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.Domain.Repositories.Interfaces
{
   public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        Customer GetCustomer(int id);
        List<Customer> GetCustomers();
        bool DeleteCustomer(int id);
    }
}
