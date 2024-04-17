using Microsoft.AspNetCore.Mvc;
using BLL;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaImgsController : ControllerBase
    {
        private readonly IPastaImg _pastaImgService;

        public PastaImgsController(IPastaImg pastaImgService)
        {
            _pastaImgService = pastaImgService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PastaImgResponceDTO>> GetPastaImgs()
        {
            return Ok(_pastaImgService.GetPastaInfos());
        }

        [HttpGet("{id}")]
        public ActionResult<PastaImgResponceDTO> GetPastaImg(int id)
        {
            var pastaImg = _pastaImgService.GetPastaInfo(id);
            if (pastaImg == null)
            {
                return NotFound();
            }
            return Ok(pastaImg);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePastaImg(int id)
        {
            _pastaImgService.DeletePastaImg(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutPastaImg(int id, PastaImgRequestDTO requestDTO)
        {
            _pastaImgService.PutPastImg(id, requestDTO);
            return NoContent();
        }

        //[HttpPost]
        //public IActionResult PostPastaImg(PastaImgRequestDTO requestDTO)
        //{
        //    _pastaImgService.PostPastImg(requestDTO);
        //    return CreatedAtAction(nameof(GetPastaImg), new { id = requestDTO.Id }, requestDTO);
        //}
    }

}
