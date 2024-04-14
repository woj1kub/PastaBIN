using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal interface IPastaHistory
    {
        IEnumerable<PastaHistoryResponseDTO> GetPastaHistories();
        PastaHistoryResponseDTO GetPastaHistory(int id);
        void PostPastaHistory(PastaHistoryRequestDTO request);
    }
}
