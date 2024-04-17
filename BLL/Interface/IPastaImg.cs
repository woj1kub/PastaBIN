using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPastaImg
    {
        public IEnumerable<PastaImgResponseDTO> GetPastaInfos();
        public PastaImgResponseDTO GetPastaInfo(int id);  
        public void DeletePastaImg(int id);
        public void PutPastImg(int id, PastaImgRequestDTO requesteDTO);
        public void PostPastImg(PastaImgRequestDTO requesteDTO);
    }
}
