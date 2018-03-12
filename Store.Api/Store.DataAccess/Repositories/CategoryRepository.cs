using Store.DataAccess.Entities;

namespace Store.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}