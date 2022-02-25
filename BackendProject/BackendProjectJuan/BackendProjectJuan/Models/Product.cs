using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Models
{
    public class Product:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 150)]
        public string Name { get; set; }
        [StringLength(maximumLength: 500)]
        public string Desc { get; set; }
        
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int Page { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercent { get; set; }
        [Range(1, 5)]
        public int Rate { get; set; }
        public bool IsAvailable { get; set; }
       
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductComment> ProductComments { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        [NotMapped]
        public List<int> ColorIds { get; set; } = new List<int>();
    }
}
