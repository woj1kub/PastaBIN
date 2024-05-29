using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PastaImageResponce
    {
        public int IDBind {set; get; }
        public byte[] Image { set; get; }
        public string GlobalKy { set; get; }
        public DateTime DeleteDate { set; get; }

    }
}
