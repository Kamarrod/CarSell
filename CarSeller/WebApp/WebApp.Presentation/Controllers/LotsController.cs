using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace WebApp.Presentation.Controllers
{
    [Route("api/lots")]
    [ApiController]
    public class LotsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public LotsController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetLots()
        {
                var lots = _service.LotService.GetAllLots(trackChanges : false);
                return Ok(lots);
        }

        [HttpGet("{id:guid}", Name = "LotById")]
        public IActionResult GetLot(Guid id)
        {
            var lot = _service.LotService.GetLot(id, trackChanges : false);
            return Ok(lot);
        }
    }
}
