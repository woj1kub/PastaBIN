using BLL.DTO;

namespace BLL.Interface
{
    public interface IPastaSharing
    {
        // Dla grup
        //Potem w kontrolerze trzeba zrobić zabezpieczenie że tylko właściciel może edytować - JWT w tym wykorzystamy
        public void AddGrupSharing(PastaGroupSharingRequest pastaGroupSharingRequest);
        // tu tak samo
        public void UpdateGrupSharing(int pastaGroupSharingID, DateTime EndSharinDate);
        // można potem przerobić wykorzystując JWT - chyba trochę bezpieczniej, można to zrobić w kontrolerze
        // trzeba dawać CookID bo to może robić tylko właściciel - edycja
        public IEnumerable<PastaGroupSharingResponce> GetPastaGroupSharingByBindID(int BindID);
        public void DeleteGrupSharing(int pastaGroupSharingID);
        // Tu dla pojedynczych użytkowników
        //Potem w kontrolerze trzeba zrobić zabezpieczenie że tylko właściciel może edytować - JWT w tym wykorzystamy
        public void AddSharingSettings(PastaSharingSettingsRequest pastaSharingSettingsRequest);
        // tu tak samo
        public void UpdateSharingSettings(int pastaSharingSettingsID, DateTime EndSharinDate);
        public void DeleteSharingSettings(int pastaSharingSettingsID);
        // można potem przerobić wykorzystując JWT - chyba trochę bezpieczniej, można to zrobić w kontrolerze
        // trzeba dawać CookID bo to może robić tylko właściciel - edycja
        public IEnumerable<PastaSharingSettingsRequest> GetPastaSharingSettingsByBindID(int BindID);
    }
}
