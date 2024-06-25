using BLL.DTO;

namespace BLL.Interface
{
    public interface IPastaSharingSettings
    {
        // Tu dla pojedynczych użytkowników
        //Potem w kontrolerze trzeba zrobić zabezpieczenie że tylko właściciel może edytować
        public bool AddSharingSettings(int cookID,PastaSharingSettingsRequest pastaSharingSettingsRequest);
        // tu tak samo
        public bool UpdateSharingSettings(int cookID, int pastaSharingSettingsID, DateTime EndSharinDate);
        public bool DeleteSharingSettings(int cookID, int pastaSharingSettingsID);
        // trzeba dawać CookID bo to może robić tylko właściciel - edycja
        public IEnumerable<PastaSharingSettingsResponse> GetPastaSharingSettingsByBindID(int cookID, int BindID);
    }
}
