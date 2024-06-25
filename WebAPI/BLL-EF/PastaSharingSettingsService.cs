using BLL.DTO;
using BLL.Interface;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;

namespace BLL_EF
{
    public class PastaSharingSettingsService : IPastaSharingSettings
    {
        private readonly PastaBINContext context;

        public PastaSharingSettingsService(PastaBINContext context)
        {
            this.context = context;
        }

        public bool AddSharingSettings(int cookID, PastaSharingSettingsRequest pastaSharingSettingsRequest)
        {
            PastaBind pastaBind = context.PastaBinds
                .SingleOrDefault(pb => pb.PastaBindID == pastaSharingSettingsRequest.PastaBindID);

            if (pastaBind == null || cookID!=pastaBind.CookID)
                return false;

            Cook cook = context.Cooks
                .SingleOrDefault(c => c.Login == pastaSharingSettingsRequest.CookLogin);
            if (cook == null || cook.CookID == cookID) 
                return false;

            context.PastaSharingSettings.Add(new PastaSharingSettings()
            {
                CreationDate = DateTime.Now,
                EndSharingDate = pastaSharingSettingsRequest.EndSharingDate,
                PastaBindID = pastaBind.PastaBindID,
                CookID=cook.CookID
            });

            context.SaveChanges();
            return true;
        }

        public bool UpdateSharingSettings(int cookID, int pastaSharingSettingsID, DateTime endSharingDate)
        {
            PastaSharingSettings pastaSharingSettings = context.PastaSharingSettings
                .Include(ps => ps.PastaBind)
                .SingleOrDefault(ps => ps.SharingSettingsID == pastaSharingSettingsID);

            if (pastaSharingSettings == null || pastaSharingSettings.PastaBind.CookID != cookID)
                return false;

            pastaSharingSettings.EndSharingDate = endSharingDate;
            context.SaveChanges();
            return true;
        }

        public bool DeleteSharingSettings(int cookID, int pastaSharingSettingsID)
        {
            PastaSharingSettings pastaSharingSettings = context.PastaSharingSettings
                .Include(ps => ps.PastaBind)
                .SingleOrDefault(ps => ps.SharingSettingsID == pastaSharingSettingsID);

            if (pastaSharingSettings == null || pastaSharingSettings.PastaBind.CookID != cookID)
                return false;

            context.PastaSharingSettings.Remove(pastaSharingSettings);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<PastaSharingSettingsResponse> GetPastaSharingSettingsByBindID(int cookID, int bindID)
        {
            PastaBind pastaBind = context.PastaBinds
                .Include(pb => pb.SharingSettings)
                    .ThenInclude(ss => ss.Cook)
                .SingleOrDefault(pb => pb.PastaBindID == bindID && pb.CookID == cookID);

            if (pastaBind == null)
                return Enumerable.Empty<PastaSharingSettingsResponse>();

            var sharingSettingsRequests = pastaBind.SharingSettings.Select(ps => new PastaSharingSettingsResponse()
            {
                PastaSharingID = ps.SharingSettingsID,
                EndSharingDate = ps.EndSharingDate,
                CookLogin = ps.Cook?.Login,
                CreationDate = ps.CreationDate
            }).ToList();

            return sharingSettingsRequests;
        }

    }

}
