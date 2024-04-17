using Microsoft.AspNetCore.Mvc;
using BLL;

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
        public IEnumerable<PastaSharingSettingsResponseDTO> GetPastaSharingSettings()
        {
            return _pastaSharingSettingsService.GetPastaSharingSettings();
        }

        [HttpGet("{id}")]
        public PastaSharingSettingsResponseDTO GetPastaSharing(int id)
        {
            var pastaSharingSetting = _pastaSharingSettingsService.GetPastaSharing(id);
            
            return pastaSharingSetting;
        }

        [HttpDelete("{id}")]
        public void DeletePastaSharing(int id)
        {
            _pastaSharingSettingsService.DeletePastaSharing(id);
        }

        [HttpPut("{id}")]
        public void PutPastaSharing(int id, PastaSharingSettingsRequestDTO requestDTO)
        {
            _pastaSharingSettingsService.PutPastaSharing(id, requestDTO);
        }

        [HttpPost]
        public void PostPastaSharing(PastaSharingSettingsRequestDTO requestDTO)
        {
            _pastaSharingSettingsService.PostPastaSharing(requestDTO);
        }
    }



}
