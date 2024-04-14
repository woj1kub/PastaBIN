using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal interface IPastaInfo
    {
        IEnumerable<PastaInfoResponceDTO> GetPastaInfos();
        PastaInfoResponceDTO GetPastaInfo(int id);
        void DeletePastaInfo(int id);
        void PutPastaInfo(int id, PastaInfoRequestDTO pasta);
        void PostPastaInfo(PastaInfoRequestDTO pasta);

    }
}
