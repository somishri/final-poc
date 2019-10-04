using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopApp.Models
{
   public class OrderPlace
    {   
        [Key]
        public int OrderId { get; set; }
        public int CusId { get; set; }
        [ForeignKey("CusId")]
        public virtual Customer Customer { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
    }
}
