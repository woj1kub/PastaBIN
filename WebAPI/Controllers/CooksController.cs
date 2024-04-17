using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CooksController : ControllerBase
    {
        private readonly ICook _cookService;

        public CooksController(ICook cookService)
        {
            _cookService = cookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CookResponceDTO>> GetCooks()
        {
            return Ok(_cookService.GetCooks());
        }

        [HttpGet("{id}")]
        public ActionResult<CookResponceDTO> GetCook(int id)
        {
            var cook = _cookService.GetCook(id);

            if (cook == null)
            {
                return NotFound();
            }

            return Ok(cook);
        }

        [HttpPost]
        public void PostCook([FromBody] CookRequestDTO cookRequest)
        {
            _cookService.PostCook(cookRequest);
        }

        [HttpPut("{id}")]
        public IActionResult PutCook(int id, CookRequestDTO cookRequest)
        {
            _cookService.PutCook(id, cookRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<CookResponceDTO> DeleteCook(int id)
        {
            _cookService.DeleteCook(id);
            return NoContent();
        }
    }
}
