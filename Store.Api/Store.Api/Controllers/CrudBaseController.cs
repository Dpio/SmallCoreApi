using System.Net;
using Microsoft.AspNetCore.Mvc;
using Store.Logic.Base.Services;
using Store.Models.Base;

namespace Store.Api.Controllers
{
    /// <summary>
    /// This is a base class for CRUD controller.
    /// </summary>
    public abstract class CrudBaseController<TEntityDto, TCreateInput, TUpdateInput> : Controller
        where TEntityDto : IEntityDto
        where TUpdateInput : IEntityDto
        where TCreateInput : ICreateEntityDto
    {
        protected readonly ICrudAppService<TEntityDto, TCreateInput, TUpdateInput> Service;

        protected CrudBaseController(ICrudAppService<TEntityDto, TCreateInput, TUpdateInput> service)
        {
            Service = service;
        }

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(IEntityDto))]
        public IActionResult Get(int id)
        {
            var dto = Service.Get(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost()]
        [Produces("application/json", Type = typeof(ICreateEntityDto))]
        [ProducesResponseType(typeof(IEntityDto), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody] TCreateInput type)
        {
            var dto = Service.Create(type);
            return Ok(dto);
        }

        [HttpPut()]
        [Produces("application/json", Type = typeof(IEntityDto))]
        public IActionResult Put([FromBody] TUpdateInput input)
        {
            var dto = Service.Update(input);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Service.Delete(id);
            return Ok();
        }
    }
}