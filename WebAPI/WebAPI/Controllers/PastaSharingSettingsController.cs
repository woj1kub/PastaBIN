using BLL.DTO;
using BLL.Interface;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PastaSharingSettingsController : ControllerBase
    {
        private readonly IPastaSharingSettings _pastaSharingSettingsService;

        public PastaSharingSettingsController(PastaSharingSettingsService pastaSharingSettingsService)
        {
            _pastaSharingSettingsService = pastaSharingSettingsService ?? throw new ArgumentNullException(nameof(pastaSharingSettingsService));
        }

        [HttpPost("add")]
        public IActionResult AddSharingSettings(int cookID, [FromBody] PastaSharingSettingsRequest pastaSharingSettingsRequest)
        {
            if (pastaSharingSettingsRequest == null)
                return BadRequest();

            if (_pastaSharingSettingsService.AddSharingSettings(cookID, pastaSharingSettingsRequest))
                return Ok();

            return NotFound("Invalid PastaBindID or user doesn't have access to it.");
        }

        [HttpPut("update/{cookID}/{pastaSharingSettingsID}")]
        public IActionResult UpdateSharingSettings(int cookID, int pastaSharingSettingsID, [FromBody] DateTime endSharingDate)
        {
            if (_pastaSharingSettingsService.UpdateSharingSettings(cookID, pastaSharingSettingsID, endSharingDate))
                return Ok();

            return NotFound();
        }

        [HttpDelete("delete/{cookID}/{pastaSharingSettingsID}")]
        public IActionResult DeleteSharingSettings(int cookID, int pastaSharingSettingsID)
        {
            if (_pastaSharingSettingsService.DeleteSharingSettings(cookID, pastaSharingSettingsID))
                return Ok();

            return NotFound();
        }

        [HttpGet("get/{cookID}/{bindID}")]
        public IActionResult GetPastaSharingSettingsByBindID(int cookID, int bindID)
        {
            var sharingSettings = _pastaSharingSettingsService.GetPastaSharingSettingsByBindID(cookID, bindID);
            return Ok(sharingSettings);
        }
    }
}

