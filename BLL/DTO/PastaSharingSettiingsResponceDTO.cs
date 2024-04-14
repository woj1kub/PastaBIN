using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PastaSharingSettiingsResponceDTO
    {
        public int ID { get; set; }
        public int IDUser { get; set; }
        public int IDPastaInfo { get; set; }
        public DateTime? EndSharingDate { get; set; }
    }

}
