using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("PastaImg")]
    public class PastaImg
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("PastaInfo")]
        public int IDPastaInfo { get; set; }

        public byte[] PastaImg { get; set; }

        public PastaInfo PastaInfo { get; set; }
    }
}
