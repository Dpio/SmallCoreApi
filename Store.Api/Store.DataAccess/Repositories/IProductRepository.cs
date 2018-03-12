using System.Collections.Generic;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllProducts(ProductFilterInput productFilterInput);
        Product GetWithAllIncludes(int id);
    }
}