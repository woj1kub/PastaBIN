using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PastaImgResponseDTO
    {
        public int ID { get; set; }
        public int IDPastaInfo { get; set; }
        public required byte[] Img { get; set; }
    }


}
