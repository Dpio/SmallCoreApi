using AutoMapper;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories;
using Store.Logic.Base.Services;
using Store.Models.Categories;

namespace Store.Logic.Impl
{
    public class CategoryService : CrudAppService<Category, CategoryDto,GetAllCategoriesInput, CreateCategoryDto, CategoryDto>, ICategoryService
    {
        public CategoryService(IGenericRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}