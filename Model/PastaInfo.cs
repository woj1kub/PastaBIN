using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("PastaInfo")]
    public class PastaInfo
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Cook")]
        public int IDUser { get; set; }

        [MaxLength(255)]
        public string Key { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? DeleteTime { get; set; }

        public bool IsActive { get; set; }

        public Cook Cook { get; set; }
        public ICollection<PastaText> PastaTexts { get; set; }
        public ICollection<PastaImg> PastaImgs { get; set; }
    }
}
