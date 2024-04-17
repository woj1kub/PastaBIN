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
        public IEnumerable<PastaSharingSettiingsResponceDTO> GetPastaSharingSettings()
        {
            return _pastaSharingSettingsService.GetPastaSharingSettiings();
        }

        [HttpGet("{id}")]
        public PastaSharingSettiingsResponceDTO GetPastaSharing(int id)
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
        public void PutPastaSharing(int id, PastaSharingSettiingsRequestDTO requestDTO)
        {
            _pastaSharingSettingsService.PutPastaSharing(id, requestDTO);
        }

        [HttpPost]
        public void PostPastaSharing(PastaSharingSettiingsRequestDTO requestDTO)
        {
            _pastaSharingSettingsService.PostPastaSharing(requestDTO);
        }
    }



}
