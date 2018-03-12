using AutoMapper;
using Store.DataAccess.Entities;
using Store.Models.Categories;

namespace Store.Logic.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CreateCategoryDto, Category>()
                .ForMember(x => x.Id, e => e.Ignore());
        }
    }
}