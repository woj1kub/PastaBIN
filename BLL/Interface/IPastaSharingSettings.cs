using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal interface IPastaSharingSettings
    {
        IEnumerable<PastaSharingSettiingsResponceDTO> GetPastaSharingSettiings();
        PastaSharingSettiingsResponceDTO GetPastaSharing(int id);
        void DeletePastaSharing(int id);
        void PutPastaSharing(int id, PastaSharingSettiingsRequestDTO requestDTO);
        void PostPastaSharing(PastaSharingSettiingsRequestDTO requestDTO);
    }
}
