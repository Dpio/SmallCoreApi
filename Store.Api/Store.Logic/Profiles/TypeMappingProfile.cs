using AutoMapper;
using Store.DataAccess.Entities;
using Store.Models.Types;

namespace Store.Logic.Profiles
{
    public class TypeMappingProfile : Profile
    {
        public TypeMappingProfile()
        {
            CreateMap<Type, TypeDto>();
            CreateMap<TypeDto, Type>();
            CreateMap<CreateTypeDto, Type>()
                .ForMember(x => x.Id, e => e.Ignore());
        }
    }
}