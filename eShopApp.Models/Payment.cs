using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopApp.Models
{
    
   public class Payment
    {

        [Key]
        public int PaymentId { get; set; }
        public int CusId { get; set; }
        [ForeignKey("CusId")]
        public virtual Customer Customer { get; set; }

        public string CustomerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpMonth { get; set; }
        public string CVV { get; set; }
    }
}
