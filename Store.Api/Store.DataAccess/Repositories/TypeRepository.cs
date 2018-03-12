using Store.DataAccess.Entities;

namespace Store.DataAccess.Repositories
{
    public class TypeRepository : GenericRepository<Type>
    {
        public TypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}