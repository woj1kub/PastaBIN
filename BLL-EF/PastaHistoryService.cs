
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL_EF
{
    internal class PastaHistoryService : IPastaHistory
    {
        private readonly PastaBINContext _context;

        public PastaHistoryService(PastaBINContext context)
        {
            _context = context;
        }

        public IEnumerable<PastaHistoryResponseDTO> GetPastaHistories()
        {
            throw new NotImplementedException();
        }

        public PastaHistoryResponseDTO GetPastaHistory(int id)
        {
            throw new NotImplementedException();
        }

        public void PostPastaHistory(PastaHistoryRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}