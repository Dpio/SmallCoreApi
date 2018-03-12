using AutoMapper;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories;
using Store.Logic.Base.Services;
using Store.Models.Types;

namespace Store.Logic.Impl
{
    /// <summary>
    /// Crud service for product types.
    /// </summary>
    public class TypeService : CrudAppService<Type, TypeDto, GetAllTypesInput, CreateTypeDto, TypeDto>, ITypeService
    {
        public TypeService(IGenericRepository<Type> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}