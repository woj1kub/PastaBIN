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
    public class PastaImgService : IPastaImg
    {
        private readonly PastaBINContext _context;

        public PastaImgService(PastaBINContext context)
        {
            _context = context;
        }
        public void DeletePastaImg(int id)
        {
            var pastaImg = _context.PastaImgs.Find(id);
            if (pastaImg != null)
            {
                _context.PastaImgs.Remove(pastaImg);
                _context.SaveChanges();
            }
        }

        public PastaImgResponceDTO GetPastaInfo(int id)
        {
            var pastaImg = _context.PastaImgs
            .Where(pi => pi.ID == id)
            .Select(pi => new PastaImgResponceDTO
            {
                ID = pi.ID,
                IDPastaInfo = pi.IDPastaInfo,
                Img = pi.Img
            }).FirstOrDefault();

            return pastaImg;
        }

        public IEnumerable<PastaImgResponceDTO> GetPastaInfos()
        {
            return _context.PastaImgs
            .Select(pi => new PastaImgResponceDTO
            {
                ID = pi.ID,
                IDPastaInfo = pi.IDPastaInfo,
                Img = pi.Img
            }).ToList();
        }

        public void PostPastImg(PastaImgRequestDTO requestDTO)
        {
            var newPastaImg = new PastaImg
            {
                IDPastaInfo = requestDTO.IDPastaInfo,
                Img = requestDTO.Img
            };

            _context.PastaImgs.Add(newPastaImg);
            _context.SaveChanges();
        }

        public void PutPastImg(int id, PastaImgRequestDTO requestDTO)
        {
            var pastaImg = _context.PastaImgs.Find(id);
            if (pastaImg != null)
            {
                pastaImg.IDPastaInfo = requestDTO.IDPastaInfo;
                pastaImg.Img = requestDTO.Img;

                _context.SaveChanges();
            }
        }
    }
}
