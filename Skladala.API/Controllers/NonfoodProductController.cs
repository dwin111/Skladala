using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skladala.App.Services;
using Skladala.Core.Models;
using Skladala.Persistence.Models;

namespace Skladala.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NonfoodProductController : ControllerBase
    {
        private readonly NonfoodProductServices _services;

        public NonfoodProductController(NonfoodProductServices services)
        {
            _services = services;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _services.GetAsync();
            if (model != null)
            {
                return Ok(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NonfoodProducts model)
        {
            NonfoodProductsDto productDto = new NonfoodProductsDto()
            {
                Name = model.Name,
                Quantity = model.Quantity,
                Group = model.Group,
                IsFoodProduct = false,
                Manufacturer = model.Manufacturer,
                Cost = model.Cost,
                ChangedPrice = 0,
                Height = model.Height,
                Width = model.Width,

            };


            bool IsCreate = await _services.CreateAsync(productDto);
            if (IsCreate)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
