using Microsoft.AspNetCore.Mvc;
using Store.Logic;
using Store.Models.Units;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    public class UnitController : CrudBaseController<UnitDto, CreateUnitDto, UnitDto>
    {
        public UnitController(IUnitService service) : base(service)
        {
        }
    }
}