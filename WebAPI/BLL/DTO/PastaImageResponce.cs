using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PastaImageResponse
    {
        public int IDBind {set; get; }
        public string Key { set; get; }
        public DateTime? DeleteDate { set; get; }
        public DateTime? CreationDate { set; get; }

    }
}
