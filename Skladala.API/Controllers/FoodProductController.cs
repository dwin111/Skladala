using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skladala.App.Services;
using Skladala.Core.Models;

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
        public async Task<IActionResult> GetAsync()
        {
            var model = await _services.GetAsync();
            if (model != null)
            {
                return Ok(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(FoodProduct model)
        {
            bool IsCreate = await _services.CreateAsync(model);
            if (IsCreate)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
