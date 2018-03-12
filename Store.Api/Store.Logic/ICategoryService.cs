using Store.Logic.Base.Services;
using Store.Models.Categories;

namespace Store.Logic
{
    public interface ICategoryService : ICrudAppService<CategoryDto, CreateCategoryDto, CategoryDto>
    {
    }
}