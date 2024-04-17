using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PastaInfoResponseDTO
    {
        public int ID { get; set; }
        public int IDUser { get; set; }
        public string Key { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool IsActive { get; set; }
    }

}
