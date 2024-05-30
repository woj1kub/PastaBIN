using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IPastaGroupSharing
    {
        // Dla grup
        //Potem w kontrolerze trzeba zrobić zabezpieczenie że tylko właściciel może edytować
        public bool AddGrupSharing(int CookID ,PastaGroupSharingRequest pastaGroupSharingRequest);
        // tu tak samo
        public bool UpdateGrupSharing(int CookID, int pastaGroupSharingID, DateTime EndSharinDate);
        // trzeba dawać CookID bo to może robić tylko właściciel - edycja
        public IEnumerable<PastaGroupSharingResponse> GetPastaGroupSharingByBindID(int BindID,int CookID);
        public bool DeleteGrupSharing(int CookID, int pastaGroupSharingID);
    }
}
