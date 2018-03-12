using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class Product : Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public virtual Type Type { get; set; }
        [ForeignKey(nameof(Type))]
        public virtual int TypeId { get; set; }
        public virtual Unit Unit { get; set; }

        [ForeignKey(nameof(Unit))]
        public virtual int UnitId { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory { get; set; } = new List<ProductCategory>();
    }
}