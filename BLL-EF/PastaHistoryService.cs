
using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL_EF
{
    public class PastaHistoryService : IPastaHistory
    {
        private readonly PastaBINContext _context;

        public PastaHistoryService(PastaBINContext context)
        {
            _context = context;
        }

        public IEnumerable<PastaHistoryResponseDTO> GetPastaHistories()
        {
            return _context.PastaHistories
            .Select(ph => new PastaHistoryResponseDTO
            {
                ID = ph.ID,
                IDUser = ph.IDUser,
                IDPastaInfo = ph.IDPastaInfo,
                VisitDate = ph.VisitDate
            }).ToList();
        }

        public PastaHistoryResponseDTO GetPastaHistory(int id)
        {
            var pastaHistory = _context.PastaHistories
            .Where(ph => ph.ID == id)
            .Select(ph => new PastaHistoryResponseDTO
            {
                ID = ph.ID,
                IDUser = ph.IDUser,
                IDPastaInfo = ph.IDPastaInfo,
                VisitDate = ph.VisitDate
            }).FirstOrDefault();

            return pastaHistory;
        }

        public void PostPastaHistory(PastaHistoryRequestDTO request)
        {
            var newPastaHistory = new PastaHistory
            {
                IDUser = request.IDUser,
                IDPastaInfo = request.IDPastaInfo,
                VisitDate = request.VisitDate
            };

            _context.PastaHistories.Add(newPastaHistory);
            _context.SaveChanges();
        }
    }
}