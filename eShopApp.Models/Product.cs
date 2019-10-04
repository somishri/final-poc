using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [Required]
        public string discount { get; set; }
        [Required]
        public int DsicountPrice { get; set; }
        [Required]
        public string ProImage { get; set; }
        public int CatId { get; set; }
        [ForeignKey("CatId")]

        public virtual Category Category { get; set; }
    }
}
