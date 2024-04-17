using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPastaText
    {
        public IEnumerable<PastaTextResponseDTO> GetPastaInfos();
        public PastaTextResponseDTO GetPastaInfo(int id);
        public void DeletePastaText(int id);
        public void PutPastText(int id, PastaTextRequestDTO requesteDTO);
        public void PostPastText(PastaTextRequestDTO requesteDTO);
    }
}
