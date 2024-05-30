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

            [HttpPost("add")]
            public IActionResult AddPastaImage([FromBody] PastaImageRequest pastaImageRequest)
            {
                if (pastaImageRequest == null)
                    return BadRequest();

                if (_pastaImgService.AddImgPasta(pastaImageRequest))
                    return Ok();

                return BadRequest("Invalid request or missing data.");
            }

            [HttpGet("getByKey/{key}/{cookID}")]
            public IActionResult GetPastaImgByKey(string key, int cookID)
            {
                try
                {
                    var pastaImageResponse = _pastaImgService.GetPastaImgByKey(key, cookID);
                    return Ok(pastaImageResponse);
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(ex.Message);
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
        }
    }

