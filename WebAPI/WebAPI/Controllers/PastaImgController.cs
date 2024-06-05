using BLL.DTO;
using BLL.Interface;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaImgController : ControllerBase
    {
        private readonly IPastaImg _pastaImgService;

        public PastaImgController(PastaImgService pastaImgService)
        {
            _pastaImgService = pastaImgService ?? throw new ArgumentNullException(nameof(pastaImgService));
        }

        [HttpPost("add/{cookID}")]
        public IActionResult AddPastaImage(int? cookID, [FromBody] PastaImageRequest pastaImageRequest)
        {
            if (pastaImageRequest == null)
                return BadRequest();
            string key;

            if ((key = _pastaImgService.AddImgPasta(cookID, pastaImageRequest)) != " ")
                return Ok(new KeyResponse() { Key = key });

            return BadRequest("Invalid request or missing data.");
        }

        [HttpGet("getByKey/{key}/{cookID}")]
        public async Task<IActionResult> GetPastaImgByKey(string key, int cookID)
        {
            try
            {
                var stream = await _pastaImgService.GetPastaImgByKey(key, cookID);
                if (stream == null)
                    return NotFound("Image not found");
                Response.Headers.Append("Data", "AAAAAAA");
                return File(stream, "image/png"); // Zwracaj obrazy w formacie PNG
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Zwróć kod odpowiedzi "500 Internal Server Error"
            }
        }


        [HttpGet("getByUser/{cookID}")]
        public IActionResult GetPastaImgByUser(int cookID)
        {
            try
            {
                var pastaImageResponses = _pastaImgService.GetPastaImgByUser(cookID);
                return Ok(pastaImageResponses);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getByUserFromPastaSharing/{cookID}")]
        public IActionResult GetPastaImgByUserFromPastaSharing(int cookID)
        {
            try
            {
                var pastaImageResponses = _pastaImgService.GetPastaImgByUserFromPastaSharing(cookID);
                return Ok(pastaImageResponses);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

