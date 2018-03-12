using Store.DataAccess.Entities;
using Store.DataAccess.Repositories;
using Store.Logic.Base.Services;
using Store.Models.Categories;

namespace Store.Logic.Impl
{
    public class CategoryService : CrudAppService<Category, CategoryDto, CreateCategoryDto, CategoryDto>, ICategoryService
    {
        public CategoryService(IGenericRepository<Category> repository) : base(repository)
        {
        }
    }
}