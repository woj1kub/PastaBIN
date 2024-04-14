using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal interface IPastaImg
    {
        IEnumerable<PastaImgResponceDTO> GetPastaInfos();
        PastaImgResponceDTO GetPastaInfo(int id);  
        void DeletePastaImg(int id);
        void PutPastImg(int id, PastaImgRequestDTO requesteDTO);
        void PostPastImg(PastaImgRequestDTO requesteDTO);
    }
}
