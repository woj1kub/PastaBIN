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
        public IEnumerable<PastaHistoryResponseDTO> GetPastaHistories()
        {
            return _pastaHistoryService.GetPastaHistories();
        }

        [HttpGet("{id}")]
        public PastaHistoryResponseDTO GetPastaHistory(int id)
        {
            var pastaHistory = _pastaHistoryService.GetPastaHistory(id);
            
            return pastaHistory;
        }

        [HttpPost]
        public void PostPastaHistory(PastaHistoryRequestDTO request)
        {
            _pastaHistoryService.PostPastaHistory(request);
        }

    }

}
