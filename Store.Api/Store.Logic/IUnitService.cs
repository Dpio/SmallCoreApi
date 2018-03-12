using Store.Logic.Base.Services;
using Store.Models.Units;

namespace Store.Logic
{
    public interface IUnitService : ICrudAppService<UnitDto, CreateUnitDto, UnitDto>
    {
    }
}