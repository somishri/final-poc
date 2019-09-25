using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopApp.Models
{
  public  class Category
    {
        [Key]
        public int CatId { get; set; }
        [Required]
        public string  CatNamr { get; set; }
    }
}
