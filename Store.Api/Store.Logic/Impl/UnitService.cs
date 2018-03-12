using AutoMapper;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories;
using Store.Logic.Base.Services;
using Store.Models.Units;

namespace Store.Logic.Impl
{
    public class UnitService : CrudAppService<Unit, UnitDto, GetAllUnitsInput, CreateUnitDto, UnitDto>, IUnitService
    {
        public UnitService(IGenericRepository<Unit> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}