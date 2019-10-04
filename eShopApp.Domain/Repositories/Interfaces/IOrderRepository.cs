using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.Domain.Repositories.Interfaces
{
  public  interface IOrderRepository
    {
        void AddOrder(OrderPlace orderPlace);
        bool UpdateOrder(OrderPlace orderPlace);
        OrderPlace GetOrder(int id);
        bool DeleteOrder(int id);
        List<OrderPlace> GetOrders();
    }
}
