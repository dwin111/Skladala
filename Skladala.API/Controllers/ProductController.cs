using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skladala.App.Services;
using Skladala.Core.Models;
using Skladala.Persistence.Models;

namespace Skladala.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductServices _services;

        public ProductController(ProductServices services)
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

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if(await _services.DeleteAsync(id))
                {
                    return Ok();
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(AllProductDto productDto)
        {
            try
            {
                if (await _services.UpdateAsync(productDto))
                {
                    return Ok();
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
