﻿using BLL.DTO;
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
                .Include(pb => pb.Cook)
                .SingleOrDefault(pb => pb.PastaBindID == pastaSharingSettingsRequest.PastaBindID && pb.CookID == cookID);

            if (pastaBind == null)
                return false;

            context.PastaSharingSettings.Add(new PastaSharingSettings()
            {
                CreationDate = DateTime.Now,
                EndSharingDate = pastaSharingSettingsRequest.EndSharingDate,
                PastaBindID = pastaBind.PastaBindID,
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

        public IEnumerable<PastaSharingSettingsRequest> GetPastaSharingSettingsByBindID(int cookID, int bindID)
        {
            PastaBind pastaBind = context.PastaBinds
                .Include(pb => pb.SharingSettings)
                .SingleOrDefault(pb => pb.PastaBindID == bindID && pb.CookID == cookID);

            if (pastaBind == null)
                return Enumerable.Empty<PastaSharingSettingsRequest>();

            return pastaBind.SharingSettings.Select(ps => new PastaSharingSettingsRequest()
            {
                PastaBindID = ps.PastaBindID,
                EndSharingDate = ps.EndSharingDate
            });
        }
    }

}