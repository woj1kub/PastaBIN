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
        public IEnumerable<CookResponseDTO> GetCooks()
        {
            return _cookService.GetCooks();
        }

        [HttpGet("{id}")]
        public CookResponseDTO GetCook(int id)
        {
            var cook = _cookService.GetCook(id);
            return cook;
        }

        [HttpPost]
        public void PostCook([FromBody] CookRequestDTO cookRequest)
        {
            _cookService.PostCook(cookRequest);
        }

        [HttpPut("{id}")]
        public void PutCook(int id, CookRequestDTO cookRequest)
        {
            _cookService.PutCook(id, cookRequest);
        }

        [HttpDelete("{id}")]
        public void DeleteCook(int id)
        {
            _cookService.DeleteCook(id);
        }
    }
}
