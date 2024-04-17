using Microsoft.AspNetCore.Mvc;
using BLL;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaImgsController : ControllerBase
    {
        private readonly IPastaImg _pastaImgService;

        public PastaImgsController(IPastaImg pastaImgService)
        {
            _pastaImgService = pastaImgService;
        }

        [HttpGet]
        public IEnumerable<PastaImgResponseDTO> GetPastaImgs()
        {
            return _pastaImgService.GetPastaInfos();
        }

        [HttpGet("{id}")]
        public PastaImgResponseDTO GetPastaImg(int id)
        {
            var pastaImg = _pastaImgService.GetPastaInfo(id);
            return pastaImg;
        }

        [HttpDelete("{id}")]
        public void DeletePastaImg(int id)
        {
            _pastaImgService.DeletePastaImg(id);
           
        }

        [HttpPut("{id}")]
        public void PutPastaImg(int id, PastaImgRequestDTO requestDTO)
        {
            _pastaImgService.PutPastImg(id, requestDTO);
        }

        [HttpPost]
        public void PostPastaImg(PastaImgRequestDTO requestDTO)
        {
            _pastaImgService.PostPastImg(requestDTO);
        }
    }

}
