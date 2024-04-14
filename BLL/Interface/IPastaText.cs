using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal interface IPastaText
    {
        IEnumerable<PastaTextResponceDTO> GetPastaInfos();
        PastaTextResponceDTO GetPastaInfo(int id);
        void DeletePastaText(int id);
        void PutPastText(int id, PastaTextRequestDTO requesteDTO);
        void PostPastText(PastaTextRequestDTO requesteDTO);
    }
}
