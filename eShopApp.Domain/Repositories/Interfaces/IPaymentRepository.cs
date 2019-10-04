using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.Domain.Repositories.Interfaces
{
   public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
        List<Payment> GetPayments();
        Payment GetPayment(int id);
    }
}
