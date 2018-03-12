using Store.Logic.Base.Services;
using Store.Models.Types;

namespace Store.Logic
{
    public interface ITypeService : ICrudAppService<TypeDto, CreateTypeDto, TypeDto>
    {
    }
}