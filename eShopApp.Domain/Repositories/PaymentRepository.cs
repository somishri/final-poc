using eShopApp.Domain.Data;
using eShopApp.Domain.Repositories.Interfaces;
using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShopApp.Domain.Repositories
{
   public class PaymentRepository:IPaymentRepository
    {
        private readonly ProductDbContext _productContext;
        public PaymentRepository(ProductDbContext productContext)
        {
            _productContext = productContext;
        }
        public List<Payment> GetPayments()
        {
            return _productContext.payments.ToList();
        }
        public void AddPayment(Payment payment)
        {
            try
            {
                _productContext.payments.Add(payment);
                _productContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
        public Payment GetPayment(int id)
        {
            return _productContext.payments.Find(id);
        }
    }
}
