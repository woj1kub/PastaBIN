using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class PastaTestService : IPastaText
    {
        private readonly PastaBINContext _context;

        public PastaTestService(PastaBINContext context)
        {
            _context = context;
        }
        public void DeletePastaText(int id)
        {
            var pastaText = _context.PastaTexts.Find(id);
            if (pastaText != null)
            {
                _context.PastaTexts.Remove(pastaText);
                _context.SaveChanges();
            }
        }

        public PastaTextResponceDTO GetPastaInfo(int id)
        {
            var pastaText = _context.PastaTexts
            .Where(pt => pt.ID == id)
            .Select(pt => new PastaTextResponceDTO
            {
                ID = pt.ID,
                IDPastaInfo = pt.IDPastaInfo,
                Pasta = pt.Pasta
            }).FirstOrDefault();

            return pastaText;
        }

        public IEnumerable<PastaTextResponceDTO> GetPastaInfos()
        {
            return _context.PastaTexts
            .Select(pt => new PastaTextResponceDTO
            {
                ID = pt.ID,
                IDPastaInfo = pt.IDPastaInfo,
                Pasta = pt.Pasta
            }).ToList();
        }

        public void PostPastText(PastaTextRequestDTO requestDTO)
        {
            var newPastaText = new PastaText
            {
                IDPastaInfo = requestDTO.IDPastaInfo,
                Pasta = requestDTO.Pasta
            };

            _context.PastaTexts.Add(newPastaText);
            _context.SaveChanges();
        }

        public void PutPastText(int id, PastaTextRequestDTO requestDTO)
        {
            var pastaText = _context.PastaTexts.Find(id);
            if (pastaText != null)
            {
                pastaText.IDPastaInfo = requestDTO.IDPastaInfo;
                pastaText.Pasta = requestDTO.Pasta;

                _context.SaveChanges();
            }
        }
    }
}
