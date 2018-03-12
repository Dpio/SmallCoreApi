using Store.Models.Base;

namespace Store.Logic.Base.Services
{
    public interface ICrudAppService<TEntityDto, in TCreateInput, in TUpdateInput> where TEntityDto : IEntityDto where TUpdateInput : IEntityDto
    {
        TEntityDto Get(int id);

        TEntityDto Create(TCreateInput input);
    
        TEntityDto Update(TUpdateInput input);

        void Delete(int id);
    }
}