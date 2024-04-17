using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPastaSharingSettings
    {
        public IEnumerable<PastaSharingSettingsResponseDTO> GetPastaSharingSettings();
        public  PastaSharingSettingsResponseDTO GetPastaSharing(int id);
        public void DeletePastaSharing(int id);
        public void PutPastaSharing(int id, PastaSharingSettingsRequestDTO requestDTO);
        public void PostPastaSharing(PastaSharingSettingsRequestDTO requestDTO);
    }
}
