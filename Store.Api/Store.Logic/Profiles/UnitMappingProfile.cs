using AutoMapper;
using Store.DataAccess.Entities;
using Store.Models.Units;

namespace Store.Logic.Profiles
{
    public class UnitMappingProfile : Profile
    {
        public UnitMappingProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<UnitDto, Unit>();
            CreateMap<CreateUnitDto, Unit>()
                .ForMember(x => x.Id, e => e.Ignore());
        }
    }
}