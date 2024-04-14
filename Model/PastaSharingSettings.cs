using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("PastaSharingSettings")]
    public class PastaSharingSettings
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int IDUser { get; set; }

        [ForeignKey("PastaInfo")]
        public int IDPastaInfo { get; set; }

        public DateTime? EndSharingDate { get; set; } 

        public Cook User { get; set; }
        public PastaInfo PastaInfo { get; set; }
    }
}
