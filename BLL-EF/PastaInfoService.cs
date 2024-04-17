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
    public class PastaInfoService : IPastaInfo
    {
        private readonly PastaBINContext _context;

        public PastaInfoService(PastaBINContext context)
        {
            _context = context;
        }
        public void DeletePastaInfo(int id)
        {
            var pastaInfo = _context.PastaInfos.Find(id);
            if (pastaInfo != null)
            {
                _context.PastaInfos.Remove(pastaInfo);
                _context.SaveChanges();
            }
        }

        public PastaInfoResponceDTO GetPastaInfo(int id)
        {
            var pastaInfo = _context.PastaInfos
            .Where(pi => pi.ID == id)
            .Select(pi => new PastaInfoResponceDTO
            {
                ID = pi.ID,
                IDUser = pi.IDUser,
                Key = pi.Key,
                CreationDate = pi.CreationDate,
                DeleteTime = pi.DeleteTime,
                IsActive = pi.IsActive
            }).FirstOrDefault();

            return pastaInfo;
        }

        public IEnumerable<PastaInfoResponceDTO> GetPastaInfos()
        {
            return _context.PastaInfos
            .Select(pi => new PastaInfoResponceDTO
            {
                ID = pi.ID,
                IDUser = pi.IDUser,
                Key = pi.Key,
                CreationDate = pi.CreationDate,
                DeleteTime = pi.DeleteTime,
                IsActive = pi.IsActive
            }).ToList();
        }

        public void PostPastaInfo(PastaInfoRequestDTO pasta)
        {
            var pastaInfo = new PastaInfo
            {
                IDUser = pasta.IDUser,
                CreationDate = pasta.CreationDate,
                DeleteTime = pasta.DeleteTime,
                IsActive = pasta.IsActive
            };

            _context.PastaInfos.Add(pastaInfo);
            _context.SaveChanges();
        }

        public void PutPastaInfo(int id, PastaInfoRequestDTO pasta)
        {
            var pastaInfo = _context.PastaInfos.Find(id);
            if (pastaInfo != null)
            {
                pastaInfo.IDUser = pasta.IDUser;
                pastaInfo.CreationDate = pasta.CreationDate;
                pastaInfo.DeleteTime = pasta.DeleteTime;
                pastaInfo.IsActive = pasta.IsActive;

                _context.SaveChanges();
            }
        }
    }
}
