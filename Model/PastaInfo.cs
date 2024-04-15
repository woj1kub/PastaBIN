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
        public ICollection<PastaHistory> PastaHistories { get; set; }
        public ICollection<PastaSharingSettings> PastaSharingSettings { get; set; }

        public void Configure(EntityTypeBuilder<PastaInfo> builder)
        {
            builder.HasOne(pi => pi.Cook)
                   .WithMany(c => c.PastaInfos)
                   .HasForeignKey(pi => pi.IDUser);

            builder.HasMany(pi => pi.PastaTexts)
                   .WithOne(pt => pt.PastaInfo)
                   .HasForeignKey(pt => pt.IDPastaInfo);

            builder.HasMany(pi => pi.PastaImgs)
                   .WithOne(pi => pi.PastaInfo)
                   .HasForeignKey(pi => pi.IDPastaInfo);

            builder.HasMany(pi => pi.PastaHistories)
                   .WithOne(ph => ph.PastaInfo)
                   .HasForeignKey(ph => ph.IDPastaInfo);

            builder.HasMany(pi => pi.PastaSharingSettings)
                   .WithOne(pss => pss.PastaInfo)
                   .HasForeignKey(pss => pss.IDPastaInfo);
        }
    }
}
