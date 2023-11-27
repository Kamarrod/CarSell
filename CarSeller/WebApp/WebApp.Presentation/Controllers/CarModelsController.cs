using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace WebApp.Presentation.Controllers
{
    [Route("api/carbrands/{carBrandId}/carmodels")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CarModelsController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetCarModels(Guid carBrandId, [FromQuery] CarModelParameters carModelParametrs)
        {
            //var carModels = await _service
            //.CarModelService
            //.GetCarModelsAsync(carBrandId, carModelParametrs ,trackChanges: false);
            var pagedResult = await _service
                .CarModelService
                .GetCarModelsAsync(carBrandId,carModelParametrs , trackChanges : false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.carModels);
        }

        [HttpGet("{id:guid}", Name = "GetCarModelByBrand")]
        [HttpHead]
        public async Task<IActionResult> GetCarModel(Guid id, Guid carBrandId)
        {
            var carModel = await _service.CarModelService.GetCarModelAsync(id, carBrandId, trackChanges: false);
            return Ok(carModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarModel(Guid carBrandId, [FromBody] CarModelForCreationDTO carModel)
        {
            if (carModel is null)
                return BadRequest("CarModelForCreationDTO object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createCarModel = await _service.CarModelService.CreateCarModelAsync(carBrandId, carModel, trackChanges : false);
            return CreatedAtRoute("GetCarModelByBrand", new { carBrandId, id = createCarModel.Id}, createCarModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCarModel(Guid id, Guid carBrandId)
        {
            await _service.CarModelService.DeleteCarModelAsync(carBrandId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCarModel(Guid id, Guid carBrandId, [FromBody] CarModelForUpdateDTO carModelForUpdateDTO)
        {
            if (carModelForUpdateDTO is null)
                return BadRequest("carModelForUpdateDTO object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.CarModelService.UpdateCarModelAsync(carBrandId, id, carModelForUpdateDTO, 
               brandTrackChanges: false, modelTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateCarModelForCarBrand(Guid id, Guid carBrandId,
            [FromBody] JsonPatchDocument<CarModelForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _service.CarModelService.GetCarModelForPatchAsync(carBrandId, id, brandTrackChanges: false, 
                                                                      modelTrackChanges: true) ;
            patchDoc.ApplyTo(result.carModelToPatch, ModelState);

            TryValidateModel(result.carModelToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.CarModelService.SaveChangesForPatchAsync(result.carModelToPatch, result.carModelEntity);
            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetCarodelsOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");
            return Ok();
        }

    }
}
