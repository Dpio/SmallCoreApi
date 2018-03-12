using System;
using System.ComponentModel.DataAnnotations;
using Store.Models.Base;

namespace Store.Models.Products
{
    public class ProductDto : EntityDto
    {
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? DeliveryDate { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        public int UnitId { get; set; }
    }
}