using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class ProductCategory : Entity
    {
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}