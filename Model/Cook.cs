using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Cook")]
    public class Cook
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Login { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public ICollection<PastaInfo> PastaInfos { get; set; }
    }
}
