using Microsoft.AspNetCore.Mvc;
using Store.Logic;
using Store.Models.Types;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    public class TypeController : CrudBaseController<TypeDto, CreateTypeDto, TypeDto>
    {
        public TypeController(ITypeService typeService) : base(typeService)
        {
        }
    }
}