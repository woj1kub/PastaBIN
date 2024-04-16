using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPastaHistory
    {
        public IEnumerable<PastaHistoryResponseDTO> GetPastaHistories();
        public PastaHistoryResponseDTO GetPastaHistory(int id);
        public void PostPastaHistory(PastaHistoryRequestDTO request);
    }
}
