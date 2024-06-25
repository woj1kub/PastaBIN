using BLL.DTO;
using BLL.Interface;
using BLL_EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CookController : ControllerBase
    {
        private readonly ICook _cookService;

        public CookController(CookService cookService)
        {
            _cookService = cookService ?? throw new ArgumentNullException(nameof(cookService));
        }

        [HttpPost("add")]
        public IActionResult AddUser([FromBody] CookRequest cookRequest)
        {
            if (cookRequest == null)
                return BadRequest();

            if (_cookService.AddUser(cookRequest))
                return Ok();

            return Conflict("User with the same login already exists.");
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_cookService.DeleteUser(id))
                return Ok();

            return NotFound();
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] CookRequest cookRequest)
        {
            if (cookRequest == null)
                return BadRequest();

            if (_cookService.UpdateUser(id, cookRequest))
                return Ok();

            return NotFound();
        }
    }
}

