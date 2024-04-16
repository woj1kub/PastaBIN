using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaHistoriesController : ControllerBase
    {
        private readonly IPastaHistory _pastaHistoryService;

        public PastaHistoriesController(IPastaHistory pastaHistoryService)
        {
            _pastaHistoryService = pastaHistoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PastaHistoryResponseDTO>> GetPastaHistories()
        {
            return Ok(_pastaHistoryService.GetPastaHistories());
        }

        [HttpGet("{id}")]
        public ActionResult<PastaHistoryResponseDTO> GetPastaHistory(int id)
        {
            var pastaHistory = _pastaHistoryService.GetPastaHistory(id);
            if (pastaHistory == null)
            {
                return NotFound();
            }
            return Ok(pastaHistory);
        }

        [HttpPost]
        public IActionResult PostPastaHistory(PastaHistoryRequestDTO request)
        {
            _pastaHistoryService.PostPastaHistory(request);
            return CreatedAtAction(nameof(GetPastaHistory), new { id = request.Id }, request);
        }
    }

}
