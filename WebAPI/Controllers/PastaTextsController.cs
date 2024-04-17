using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaTextsController : ControllerBase
    {
        private readonly IPastaText _pastaTextService;

        public PastaTextsController(IPastaText pastaTextService)
        {
            _pastaTextService = pastaTextService;
        }

        [HttpGet]
        public  IEnumerable<PastaTextResponceDTO> GetPastaTexts()
        {
            return _pastaTextService.GetPastaInfos();
        }

        [HttpGet("{id}")]
        public PastaTextResponceDTO GetPastaText(int id)
        {
            var pastaText = _pastaTextService.GetPastaInfo(id);
            
            return pastaText;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePastaText(int id)
        {
            _pastaTextService.DeletePastaText(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public void PutPastaText(int id, PastaTextRequestDTO requestDTO)
        {
            _pastaTextService.PutPastText(id, requestDTO);
        }

        [HttpPost]
        public void postpastatext(PastaTextRequestDTO requestdto)
        {
            _pastaTextService.PostPastText(requestdto);
        }
    }


}
