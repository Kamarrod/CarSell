using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace WebApp.Presentation.Controllers
{
    [Route("api/lots")]
    [ApiController]
    public class LotsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public LotsController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetLots([FromQuery] LotParameters lotParameters)
        {
                var pagedResult = await _service.LotService.GetAllLotsAsync( lotParameters,trackChanges : false);
                return Ok(pagedResult.lots);
        }

        [HttpGet("{id:guid}", Name = "LotById")]
        public async Task<IActionResult> GetLot(Guid id)
        {
            var lot = await _service.LotService.GetLotAsync(id, trackChanges : false);
            return Ok(lot);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateLot([FromBody] LotForCreationDTO lotForCreation)
        {
            if (lotForCreation is null)
                return BadRequest("LotForCreationDTO object is null");
            var createLot = await _service.LotService.CreateLotAsync(lotForCreation, trackChanges : false);
            return CreatedAtRoute("LotById", new { id = createLot.Id }, createLot);

        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteLot(Guid id)
        {
            await _service.LotService.DeleteLotAsync(id,trackChanges:false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateLot(Guid id, [FromBody] LotForUpdateDTO lotForUpdate)
        {
            if (lotForUpdate is null)
                return BadRequest("LotForUpdateDTO object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.LotService.UpdateLotAsync(id, lotForUpdate, trackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateLot(Guid id, [FromBody] JsonPatchDocument<LotForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _service.LotService.GetLotForPatchAsync(id, trackChanges : true);

            patchDoc.ApplyTo(result.lotToPatch, ModelState);
            TryValidateModel(result.lotToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.LotService.SaveChangesForPatchAsync(result.lotToPatch, result.lotEntity);
            return NoContent();
        }
    }
}
