using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace WebApp.Presentation.Controllers
{
    [Route("api/carbrands")]
    [ApiController]
    public class CarBrandsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CarBrandsController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetCarBrands()
        {
            
            var carBrands = await _service.CarBrandService.GetAllCarBrandsAsync(trackChanges: false);
                return Ok(carBrands);
        }

        [HttpGet("{id:guid}", Name = "CarBrandById")]
        public async Task<IActionResult> GetCarBrand(Guid id)
        {
            var carBrand = await _service.CarBrandService.GetCarBrandAsync(id, trackChanges: false);
            return Ok(carBrand);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarBrand([FromBody] CarBrandForCreationDTO carBrand)
        {
            if (carBrand == null)
                return BadRequest("CarBrandForCreationDTO object is null");

            var createCarBrand = await _service.CarBrandService.CreateCarBrandAsync(carBrand);
            return CreatedAtRoute("CarBrandById", new { id = createCarBrand.Id}, createCarBrand);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCarBrand(Guid id)
        {
            await _service.CarBrandService.DeleteCarBrandAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCarBrand(Guid id, [FromBody] CarBrandForUpdateDTO carBrand)
        {
            if (carBrand is null)
                return BadRequest("CarBrandForUpdateDTO object is null");

            await _service.CarBrandService.UpdateCarBrandAsync(id, carBrand, trackChanges: true);
            return NoContent();
        }
    }
}
