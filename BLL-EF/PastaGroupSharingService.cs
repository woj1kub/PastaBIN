using BLL.DTO;
using BLL.Interface;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;

namespace BLL_EF
{
    public class PastaGroupSharingService : IPastaGroupSharing
    {
        private readonly PastaBINContext context;

        public PastaGroupSharingService(PastaBINContext context)
        {
            this.context = context;
        }

        public bool AddGrupSharing(int cookID, PastaGroupSharingRequest pastaGroupSharingRequest)
        {
            PastaBind pastaBind = context.PastaBinds
                .Include(pb => pb.Cook)
                .SingleOrDefault(pb => pb.PastaBindID == pastaGroupSharingRequest.PastaBindID && pb.CookID == cookID);

            if (pastaBind == null)
                return false;

            string groupKey;
            do
            {
                groupKey = KeyGenerator.GenerateKey();
            } while (context.PastaBinds.Any(p => p.GlobalKey == groupKey)
                || context.PastaGroupSharing.Any(pg => pg.GroupKey == groupKey));

            context.PastaGroupSharing.Add(new PastaGroupSharing()
            {
                GroupKey = groupKey,
                CreationDate = DateTime.Now,
                EndSharingDate = pastaGroupSharingRequest.EndSharingDate,
                PastaBindID = pastaBind.PastaBindID,
            });

            context.SaveChanges();
            return true;
        }

        public bool DeleteGrupSharing(int cookID, int pastaGroupSharingID)
        {
            PastaGroupSharing pastaGroupSharing = context.PastaGroupSharing
                .Include(pg => pg.PastaBind)
                .SingleOrDefault(pg => pg.GroupSharingID == pastaGroupSharingID);

            if (pastaGroupSharing == null || pastaGroupSharing.PastaBind.CookID != cookID)
                return false;

            context.PastaGroupSharing.Remove(pastaGroupSharing);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<PastaGroupSharingResponse> GetPastaGroupSharingByBindID(int bindID, int cookID)
        {
            PastaBind pastaBind = context.PastaBinds
                .Include(pb => pb.GroupSharing)
                .SingleOrDefault(pb => pb.PastaBindID == bindID && pb.CookID == cookID);

            if (pastaBind == null)
                return new List<PastaGroupSharingResponse>();

            List<PastaGroupSharingResponse> pastaGroupSharings = new List<PastaGroupSharingResponse>();
            foreach (var item in pastaBind.GroupSharing)
            {
                pastaGroupSharings.Add(new PastaGroupSharingResponse()
                {
                    PastaGroupID = item.PastaBindID,
                    GroupKey = item.GroupKey,
                    EndSharingDate = item.EndSharingDate,
                    CreationDate = item.CreationDate
                });
            }
            return pastaGroupSharings;
        }

        public bool UpdateGrupSharing(int cookID, int pastaGroupSharingID, DateTime endSharingDate)
        {
            PastaGroupSharing pastaGroupSharing = context.PastaGroupSharing
                .Include(pg => pg.PastaBind)
                .SingleOrDefault(pg => pg.GroupSharingID == pastaGroupSharingID);

            if (pastaGroupSharing == null || pastaGroupSharing.PastaBind.CookID != cookID)
                return false;

            pastaGroupSharing.EndSharingDate = endSharingDate;
            context.SaveChanges();
            return true;
        }
    }


}
