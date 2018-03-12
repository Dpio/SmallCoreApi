using Store.DataAccess.Entities;

namespace Store.DataAccess.Repositories
{
    public class UnitRepository : GenericRepository<Unit>
    {
        public UnitRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}