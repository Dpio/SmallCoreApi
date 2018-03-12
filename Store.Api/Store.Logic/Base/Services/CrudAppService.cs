using AutoMapper;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories;
using Store.Models.Base;

namespace Store.Logic.Base.Services
{
    public abstract class CrudAppService<TEntity, TEntityDto, TGetAllInput, TCreateInput, TUpdateInput>
        : CrudServiceBase<TEntity, TEntityDto, TCreateInput, TUpdateInput>,
            ICrudAppService<TEntityDto, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity
        where TEntityDto : IEntityDto
        where TUpdateInput : IEntityDto
    {
        protected CrudAppService(IGenericRepository<TEntity> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public virtual TEntityDto Get(int id)
        {
            var entity = GetEntityById(id);
            return MapToEntityDto(entity);
        }

        public virtual TEntityDto Create(TCreateInput input)
        {
            var entity = MapToEntity(input);

            Repository.Add(entity);
            Repository.SaveChanges();

            return MapToEntityDto(entity);
        }

        public virtual TEntityDto Update(TUpdateInput input)
        {
            var entity = GetEntityById(input.Id);

            MapToEntity(input, entity);
            Repository.SaveChanges();

            return MapToEntityDto(entity);
        }

        public virtual void Delete(int id)
        {
            Repository.Remove(id);
            Repository.SaveChanges();
        }

        protected virtual TEntity GetEntityById(int id)
        {
            return Repository.Get(id);
        }
    }
}