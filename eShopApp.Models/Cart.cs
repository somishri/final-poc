﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopApp.Models
{
    
   public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int CusId { get; set; }
        [ForeignKey("CusId")]
        public virtual Customer Customer { get; set; }
        public int Id { get; set; }
        [ForeignKey("Id")]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public string name { get; set; }
        public int  Price { get; set; }
        public int OrderQuantity { get; set; }
    }
}