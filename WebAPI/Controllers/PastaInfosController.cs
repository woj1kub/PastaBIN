using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaInfosController : ControllerBase
    {
        private readonly IPastaInfo _pastaInfoService;

        public PastaInfosController(IPastaInfo pastaInfoService)
        {
            _pastaInfoService = pastaInfoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PastaInfoResponceDTO>> GetPastaInfos()
        {
            return Ok(_pastaInfoService.GetPastaInfos());
        }

        [HttpGet("{id}")]
        public ActionResult<PastaInfoResponceDTO> GetPastaInfo(int id)
        {
            var pastaInfo = _pastaInfoService.GetPastaInfo(id);
            if (pastaInfo == null)
            {
                return NotFound();
            }
            return Ok(pastaInfo);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePastaInfo(int id)
        {
            _pastaInfoService.DeletePastaInfo(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutPastaInfo(int id, PastaInfoRequestDTO pasta)
        {
            _pastaInfoService.PutPastaInfo(id, pasta);
            return NoContent();
        }

        //[HttpPost]
        //public IActionResult PostPastaInfo(PastaInfoRequestDTO pasta)
        //{
        //    _pastaInfoService.PostPastaInfo(pasta);
        //    return CreatedAtAction(nameof(GetPastaInfo), new { id = pasta.Id }, pasta);
        //}
    }



}
