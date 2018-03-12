using AutoMapper;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories;
using Store.Models.Base;

namespace Store.Logic.Base.Services
{
    /// <summary>
    /// This is a base class for CRUD services.
    /// </summary>
    public abstract class CrudServiceBase<TEntity, TEntityDto, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity
        where TEntityDto : IEntityDto
        where TUpdateInput : IEntityDto
    {
        /// <summary>
        /// Reference to the object to object mapper.
        /// </summary>
        public IMapper Mapper { get; set; }

        protected readonly IGenericRepository<TEntity> Repository;

        protected CrudServiceBase(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        /// <summary>
        /// Maps <see cref="TEntity"/> to <see cref="TEntityDto"/>.
        /// It uses <see cref="IMapper"/>.
        /// </summary>
        protected virtual TEntityDto MapToEntityDto(TEntity entity)
        {
            return Mapper.Map<TEntityDto>(entity);
        }

        /// <summary>
        /// Maps <see cref="TEntityDto"/> to <see cref="TEntity"/> to create a new entity.
        /// It uses <see cref="IMapper"/>.
        /// </summary>
        protected virtual TEntity MapToEntity(TCreateInput createInput)
        {
            return Mapper.Map<TEntity>(createInput);
        }

        /// <summary>
        /// Maps <see cref="TUpdateInput"/> to <see cref="TEntity"/> to update the entity.
        /// It uses <see cref="IMapper"/>.
        /// </summary>
        protected virtual void MapToEntity(TUpdateInput updateInput, TEntity entity)
        {
            Mapper.Map(updateInput, entity);
        }
    }
}