using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaInfosController : ControllerBase
    {
        private readonly IPastaInfo _pastaInfoService;

        public PastaInfosController(IPastaInfo pastaInfoService)
        {
            _pastaInfoService = pastaInfoService;
        }

        [HttpGet]
        public IEnumerable<PastaInfoResponceDTO> GetPastaInfos()
        {
            return _pastaInfoService.GetPastaInfos();
        }

        [HttpGet("{id}")]
        public PastaInfoResponceDTO GetPastaInfo(int id)
        {
            var pastaInfo = _pastaInfoService.GetPastaInfo(id);

            return  pastaInfo;
        }

        [HttpDelete("{id}")]
        public void DeletePastaInfo(int id)
        {
            _pastaInfoService.DeletePastaInfo(id);
        }

        [HttpPut("{id}")]
        public void PutPastaInfo(int id, PastaInfoRequestDTO pasta)
        {
            _pastaInfoService.PutPastaInfo(id, pasta);
        }

        [HttpPost]
        public void PostPastaInfo(PastaInfoRequestDTO pasta)
        {
            _pastaInfoService.PostPastaInfo(pasta);
        }
    }



}
