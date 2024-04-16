using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPastaImg
    {
        public IEnumerable<PastaImgResponceDTO> GetPastaInfos();
        public PastaImgResponceDTO GetPastaInfo(int id);  
        public void DeletePastaImg(int id);
        public void PutPastImg(int id, PastaImgRequestDTO requesteDTO);
        public void PostPastImg(PastaImgRequestDTO requesteDTO);
    }
}
