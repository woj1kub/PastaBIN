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
    public class PastaSharingSettingsService : IPastaSharingSettings
    {
        private readonly PastaBINContext _context;

        public PastaSharingSettingsService(PastaBINContext context)
        {
            _context = context;
        }
        public void DeletePastaSharing(int id)
        {
            var sharingSetting = _context.PastaSharingSettings.Find(id);
            if (sharingSetting != null)
            {
                _context.PastaSharingSettings.Remove(sharingSetting);
                _context.SaveChanges();
            }
        }

        public PastaSharingSettiingsResponceDTO GetPastaSharing(int id)
        {
            var sharingSetting = _context.PastaSharingSettings
                .Where(pss => pss.ID == id)
                .Select(pss => new PastaSharingSettiingsResponceDTO
                {
                    ID = pss.ID,
                    IDUser = pss.IDUser,
                    IDPastaInfo = pss.IDPastaInfo,
                    EndSharingDate = pss.EndSharingDate
                })
                .FirstOrDefault();

            return sharingSetting;
        }

        public IEnumerable<PastaSharingSettiingsResponceDTO> GetPastaSharingSettiings()
        {
            return _context.PastaSharingSettings
            .Select(pss => new PastaSharingSettiingsResponceDTO
            {
                ID = pss.ID,
                IDUser = pss.IDUser,
                IDPastaInfo = pss.IDPastaInfo,
                EndSharingDate = pss.EndSharingDate
            })
            .ToList();
        }

        public void PostPastaSharing(PastaSharingSettiingsRequestDTO requestDTO)
        {
            var newSharingSetting = new PastaSharingSettings
            {
                IDUser = requestDTO.IDUser,
                IDPastaInfo = requestDTO.IDPastaInfo,
                EndSharingDate = requestDTO.EndSharingDate
            };

            _context.PastaSharingSettings.Add(newSharingSetting);
            _context.SaveChanges();
        }

        public void PutPastaSharing(int id, PastaSharingSettiingsRequestDTO requestDTO)
        {
            var sharingSetting = _context.PastaSharingSettings.Find(id);
            if (sharingSetting != null)
            {
                sharingSetting.IDUser = requestDTO.IDUser;
                sharingSetting.IDPastaInfo = requestDTO.IDPastaInfo;
                sharingSetting.EndSharingDate = requestDTO.EndSharingDate;

                _context.SaveChanges();
            }
        }
    }
}
