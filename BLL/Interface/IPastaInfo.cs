using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPastaInfo
    {
        public IEnumerable<PastaInfoResponseDTO> GetPastaInfos();
        public PastaInfoResponseDTO GetPastaInfo(int id);
        public void DeletePastaInfo(int id);
        public void PutPastaInfo(int id, PastaInfoRequestDTO pasta);
        public void PostPastaInfo(PastaInfoRequestDTO pasta);

    }
}
