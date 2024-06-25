using BLL.DTO;
using BLL.Interface;
using BLL_EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class PastaGroupSharingController : ControllerBase
    {
        private readonly IPastaGroupSharing _pastaGroupSharingService;

        public PastaGroupSharingController(PastaGroupSharingService pastaGroupSharingService)
        {
            _pastaGroupSharingService = pastaGroupSharingService ?? throw new ArgumentNullException(nameof(pastaGroupSharingService));
        }
        [HttpPost("add/{cookID}")]
        public IActionResult AddGroupSharing(int cookID, [FromBody] PastaGroupSharingRequest pastaGroupSharingRequest)
        {
            if (pastaGroupSharingRequest == null)
                return BadRequest();
            string key = _pastaGroupSharingService.AddGrupSharing(cookID, pastaGroupSharingRequest);
            if (key != "")
                return Ok(new KeyResponse() { Key = key });

            return NotFound("Invalid PastaBindID or user doesn't have access to it.");
        }
        [HttpDelete("delete/{cookID}/{pastaGroupSharingID}")]
        public IActionResult DeleteGroupSharing(int cookID, int pastaGroupSharingID)
        {
            if (_pastaGroupSharingService.DeleteGrupSharing(cookID, pastaGroupSharingID))
                return Ok();

            return NotFound();
        }
        [HttpGet("get/{bindID}/{cookID}")]
        public IActionResult GetPastaGroupSharingByBindID(int bindID, int cookID)
        {
            var pastaGroupSharings = _pastaGroupSharingService.GetPastaGroupSharingByBindID(bindID, cookID);
            return Ok(pastaGroupSharings);
        }
        [HttpPut("update/{cookID}/{pastaGroupSharingID}")]
        public IActionResult UpdateGroupSharing(int cookID, int pastaGroupSharingID, [FromBody] DateTime endSharingDate)
        {
            if (_pastaGroupSharingService.UpdateGrupSharing(cookID, pastaGroupSharingID, endSharingDate))
                return Ok();

            return NotFound();
        }
    }
}
