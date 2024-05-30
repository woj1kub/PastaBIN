using BLL.DTO;
using BLL.Interface;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaTxtController : ControllerBase
    {
        private readonly IPastaTxt _pastaTxtService;

        public PastaTxtController(PastaTxtService pastaTxtService)
        {
            _pastaTxtService = pastaTxtService ?? throw new ArgumentNullException(nameof(pastaTxtService));
        }

        [HttpPost("add")]
        public IActionResult AddTxtPasta([FromBody] PastaTextRequest pastaTextRequest)
        {
            if (pastaTextRequest == null)
                return BadRequest();

            if (_pastaTxtService.AddTxtPasta(pastaTextRequest))
                return Ok();

            return BadRequest("Invalid request or missing data.");
        }

        [HttpGet("getByKey/{key}/{cookID}")]
        public IActionResult GetPastaTxtByKey(string key, int cookID)
        {
            try
            {
                var pastaTextResponse = _pastaTxtService.GetPastaTxtByKey(key, cookID);
                return Ok(pastaTextResponse);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("getByUser/{cookID}")]
        public IActionResult GetPastaTxtByUser(int cookID)
        {
            try
            {
                var pastaTextResponses = _pastaTxtService.GetPastaTxtByUser(cookID);
                return Ok(pastaTextResponses);
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

