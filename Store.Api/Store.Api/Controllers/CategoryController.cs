using Microsoft.AspNetCore.Mvc;
using Store.Logic;
using Store.Models.Categories;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : CrudBaseController<CategoryDto, CreateCategoryDto, CategoryDto>
    {
        public CategoryController(ICategoryService service) : base(service)
        {
        }
    }
}