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
  public  class OrderRespository : IOrderRepository
    
        {
            private readonly ProductDbContext _productContext;
            public OrderRespository(ProductDbContext productContext)
            {
                _productContext = productContext;
            }
            public List<OrderPlace> GetOrders()
            {
                return _productContext.Orders.ToList();
            }
            public void AddOrder(OrderPlace orderPlace )
            {
                try
                {
                    _productContext.Orders.Add(orderPlace);
                    _productContext.SaveChanges();
                }
                catch (Exception ex)
                {

                }

            }
            public bool UpdateOrder(OrderPlace orderPlace)
            {
               
                _productContext.Entry(orderPlace).State = EntityState.Modified;
                _productContext.SaveChanges();
                return true;
              
            }

            public OrderPlace GetOrder(int id)
            {
                return _productContext.Orders.Find(id);
            }

            public bool DeleteOrder(int id)
            {
               OrderPlace orderPlace = GetOrder(id);
                _productContext.Entry(orderPlace).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _productContext.SaveChanges();
                return true;
            }
        
    }
}
