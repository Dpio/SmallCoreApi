using AutoMapper;
using Store.Logic.Profiles;

namespace Store.Api
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Get()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new TypeMappingProfile());
                c.AddProfile(new ProductMappingProfile());
                c.AddProfile(new CategoryMappingProfile());
                c.AddProfile(new UnitMappingProfile());
            });
            return mapperConfiguration;
        }
    }
}