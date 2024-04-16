using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPastaSharingSettings
    {
        public IEnumerable<PastaSharingSettiingsResponceDTO> GetPastaSharingSettiings();
        public  PastaSharingSettiingsResponceDTO GetPastaSharing(int id);
        public void DeletePastaSharing(int id);
        public void PutPastaSharing(int id, PastaSharingSettiingsRequestDTO requestDTO);
        public void PostPastaSharing(PastaSharingSettiingsRequestDTO requestDTO);
    }
}
