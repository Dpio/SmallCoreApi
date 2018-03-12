using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.Common;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetAllProducts(ProductFilterInput productFilterInput)
        {
            var products = Entities
                .Include(product => product.Type)
                .Include(product => product.Unit)
                .Include(product => product.ProductCategory)
                .ThenInclude(pc => pc.Category)
                .Where(product => (productFilterInput.CategoryCode.IsNullOrWhiteSpace() || (product.ProductCategory != null 
                                    && product.ProductCategory.Any(pc => pc.Category.Code == productFilterInput.CategoryCode))) 
                                  && (productFilterInput.TypeCode.IsNullOrWhiteSpace() || (product.Type != null 
                                    && product.Type.Code == productFilterInput.TypeCode)) 
                                  && (productFilterInput.UnitCode.IsNullOrWhiteSpace() || (product.Unit != null 
                                    && product.Unit.Code == productFilterInput.UnitCode)))
                .OrderBy(p => p.Id)
                .Skip(productFilterInput.SkipCount)
                .Take(productFilterInput.MaxResultCount);
            return products.ToList();
        }

        public Product GetWithAllIncludes(int id)
        {
            var product = Entities.Include(p => p.Type)
                .Include(p => p.Unit)
                .Include(p => p.ProductCategory)
                .ThenInclude(pc => pc.Category)
                .Single(p => p.Id == id);
            return product;
        }
    }
}