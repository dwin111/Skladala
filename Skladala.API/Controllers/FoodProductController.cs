using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skladala.App.Services;
using Skladala.Core.Models;
using Skladala.Persistence.Models;

namespace Skladala.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodProductController : ControllerBase
    {

        private readonly FoodProductServices _services;

        public FoodProductController(FoodProductServices services)
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
        public async Task<IActionResult> Create(FoodProduct model)
        {

            FoodProductDto productDto = new FoodProductDto()
            {
                Name = model.Name,
                Quantity = model.Quantity,
                ExpirationDate = model.ExpirationDate,
                DateManufacture = model.DateManufacture,
                Group = model.Group,
                IsFoodProduct = true,
                Manufacturer = model.Manufacturer,
                Cost = model.Cost,
                ChangedPrice = 0,
                Weight = model.Weight,
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
