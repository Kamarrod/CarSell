using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
                var lots = await _service.LotService.GetAllLotsAsync( lotParameters,trackChanges : false);
                return Ok(lots);
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
            //var access_token = User.Claims.FirstOrDefault(c => c.Type == "access_token")?.Value;

            foreach (var claim in User.Claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
            }
            var createLot = await _service.LotService.CreateLotAsync(lotForCreation, trackChanges : false);
            return CreatedAtRoute("CarLotById", new { id = createLot.Id }, createLot);

        }
    }
}
