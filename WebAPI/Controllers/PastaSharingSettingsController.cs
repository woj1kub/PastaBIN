using Microsoft.AspNetCore.Mvc;
using BLL.DTO;
using Interface.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaSharingSettingsController : ControllerBase
    {
        private readonly IPastaSharingSettings _pastaSharingSettingsService;

        public PastaSharingSettingsController(IPastaSharingSettings pastaSharingSettingsService)
        {
            _pastaSharingSettingsService = pastaSharingSettingsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PastaSharingSettiingsResponceDTO>> GetPastaSharingSettings()
        {
            return Ok(_pastaSharingSettingsService.GetPastaSharingSettiings());
        }

        [HttpGet("{id}")]
        public ActionResult<PastaSharingSettiingsResponceDTO> GetPastaSharing(int id)
        {
            var pastaSharingSetting = _pastaSharingSettingsService.GetPastaSharing(id);
            if (pastaSharingSetting == null)
            {
                return NotFound();
            }
            return Ok(pastaSharingSetting);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePastaSharing(int id)
        {
            _pastaSharingSettingsService.DeletePastaSharing(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutPastaSharing(int id, PastaSharingSettiingsRequestDTO requestDTO)
        {
            _pastaSharingSettingsService.PutPastaSharing(id, requestDTO);
            return NoContent();
        }

        [HttpPost]
        public IActionResult PostPastaSharing(PastaSharingSettiingsRequestDTO requestDTO)
        {
            _pastaSharingSettingsService.PostPastaSharing(requestDTO);
            return CreatedAtAction(nameof(GetPastaSharing), new { id = requestDTO.Id }, requestDTO);
        }
    }



}
