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
        public ActionResult<IEnumerable<PastaTextResponceDTO>> GetPastaTexts()
        {
            return Ok(_pastaTextService.GetPastaInfos());
        }

        [HttpGet("{id}")]
        public ActionResult<PastaTextResponceDTO> GetPastaText(int id)
        {
            var pastaText = _pastaTextService.GetPastaInfo(id);
            if (pastaText == null)
            {
                return NotFound();
            }
            return Ok(pastaText);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePastaText(int id)
        {
            _pastaTextService.DeletePastaText(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutPastaText(int id, PastaTextRequestDTO requestDTO)
        {
            _pastaTextService.PutPastText(id, requestDTO);
            return NoContent();
        }

        //[HttpPost]
        //public IActionResult PostPastaText(PastaTextRequestDTO requestDTO)
        //{
        //    _pastaTextService.PostPastText(requestDTO);
        //    return CreatedAtAction(nameof(GetPastaText), new { id = requestDTO.Id }, requestDTO);
        //}
    }


}
